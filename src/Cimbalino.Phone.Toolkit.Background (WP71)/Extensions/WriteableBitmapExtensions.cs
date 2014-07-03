// ****************************************************************************
// <copyright file="WriteableBitmapExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>28-10-2013</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Cimbalino.Phone.Toolkit.Compression;
using Cimbalino.Phone.Toolkit.Helpers;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="WriteableBitmap"/> instances.
    /// </summary>
    public static class WriteableBitmapExtensions
    {
        private const string PngChunkTypeHeader = "IHDR";
        private const string PngChunkTypePhysical = "pHYs";
        private const string PngChunkTypeGamma = "gAMA";
        private const string PngChunkTypeData = "IDAT";
        private const string PngChunkTypeEnd = "IEND";

        private const byte PngHeaderBitDepth = 8;
        private const byte PngHeaderColorType = 6;
        private const byte PngHeaderCompressionMethod = 0;
        private const byte PngHeaderFilterMethod = 0;
        private const byte PngHeaderInterlaceMethod = 0;

        private const int MaximumChunkSize = 0xFFFF;
        private const double MetreToInch = 39.3700787d;

        /// <summary>
        /// Encodes a WriteableBitmap object into a PNG stream.
        /// </summary>
        /// <param name="writeableBitmap">The writeable bitmap.</param>
        /// <param name="outputStream">The image data stream.</param>
        public static void SavePng(this WriteableBitmap writeableBitmap, Stream outputStream)
        {
            SavePng(writeableBitmap, outputStream, new WriteableBitmapSavePngParameters());
        }

        /// <summary>
        /// Encodes a WriteableBitmap object into a PNG stream.
        /// </summary>
        /// <param name="writeableBitmap">The writeable bitmap.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <param name="desiredSize">The desired size of the png from the top left corner.</param>
        public static void SavePng(this WriteableBitmap writeableBitmap, Stream outputStream, Size desiredSize)
        {
            SavePng(writeableBitmap, outputStream, new WriteableBitmapSavePngParameters(), desiredSize);
        }

        /// <summary>
        /// Encodes a WriteableBitmap object into a PNG stream, using the specified output compression.
        /// </summary>
        /// <param name="writeableBitmap">The writeable bitmap.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <param name="compressionLevel">The image compression level.</param>
        public static void SavePng(this WriteableBitmap writeableBitmap, Stream outputStream, CompressionLevel compressionLevel)
        {
            SavePng(writeableBitmap, outputStream, new WriteableBitmapSavePngParameters { CompressionLevel = compressionLevel });
        }

        /// <summary>
        /// Encodes a WriteableBitmap object into a PNG stream, using the specified output <see cref="WriteableBitmapSavePngParameters"/>.
        /// </summary>
        /// <param name="writeableBitmap">The writeable bitmap.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <param name="parameters">The image save parameters.</param>
        public static void SavePng(this WriteableBitmap writeableBitmap, Stream outputStream, WriteableBitmapSavePngParameters parameters)
        {
            SavePng(writeableBitmap, outputStream, parameters, new Size(writeableBitmap.PixelWidth, writeableBitmap.PixelHeight));
        }

        /// <summary>
        /// Encodes a WriteableBitmap object into a PNG stream, using the specified output <see cref="WriteableBitmapSavePngParameters"/>.
        /// </summary>
        /// <param name="writeableBitmap">The writeable bitmap.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <param name="parameters">The image save parameters.</param>
        /// <param name="desiredSize">The desired size of the png from the top left corner.</param>
        public static void SavePng(this WriteableBitmap writeableBitmap, Stream outputStream, WriteableBitmapSavePngParameters parameters, Size desiredSize)
        {
            if (desiredSize.Width > writeableBitmap.PixelWidth) throw new InvalidOperationException("HorizontalResolution must be smaller that PixleWidth");
            if (desiredSize.Height > writeableBitmap.PixelHeight) throw new InvalidOperationException("VerticalResolution must be smaller that PixleHeight");

            WriteHeader(outputStream, desiredSize);

            WritePhysics(outputStream, parameters);

            WriteGamma(outputStream, parameters);

            WriteDataChunks(outputStream, writeableBitmap, parameters, desiredSize);

            WriteFooter(outputStream);

            outputStream.Flush();
        }
        /// <summary>
        /// Encodes a WriteableBitmap object into a PNG stream.
        /// </summary>
        /// <param name="writeableBitmap">The writeable bitmap.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task SavePngAsync(this WriteableBitmap writeableBitmap, Stream outputStream)
        {
            return Task.Factory.StartNew(() =>
            {
                writeableBitmap.SavePng(outputStream);
            });
        }

        /// <summary>
        /// Encodes a WriteableBitmap object into a PNG stream, using the specified output compression.
        /// </summary>
        /// <param name="writeableBitmap">The writeable bitmap.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <param name="compressionLevel">The image compression level.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task SavePngAsync(this WriteableBitmap writeableBitmap, Stream outputStream, CompressionLevel compressionLevel)
        {
            return Task.Factory.StartNew(() =>
            {
                writeableBitmap.SavePng(outputStream, compressionLevel);
            });
        }

        /// <summary>
        /// Encodes a WriteableBitmap object into a PNG stream, using the specified output <see cref="WriteableBitmapSavePngParameters"/>.
        /// </summary>
        /// <param name="writeableBitmap">The writeable bitmap.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <param name="parameters">The image save parameters.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task SavePngAsync(this WriteableBitmap writeableBitmap, Stream outputStream, WriteableBitmapSavePngParameters parameters)
        {
            return Task.Factory.StartNew(() =>
            {
                writeableBitmap.SavePng(outputStream, parameters);
            });
        }

        /// <summary>
        /// Encodes a WriteableBitmap object into a JPEG stream, with parameters for setting the target quality of the JPEG file.
        /// </summary>
        /// <param name="writeableBitmap">The WriteableBitmap object.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <param name="quality">This parameter represents the quality of the JPEG photo with a range between 0 and 100, with 100 being the best photo quality. We recommend that you do not fall lower than a value of 70. because JPEG picture quality diminishes significantly below that level. </param>
        public static void SaveJpeg(this WriteableBitmap writeableBitmap, Stream outputStream, int quality)
        {
            writeableBitmap.SaveJpeg(outputStream, writeableBitmap.PixelWidth, writeableBitmap.PixelHeight, 0, quality);
        }

        /// <summary>
        /// Encodes a WriteableBitmap object into a JPEG stream, with parameters for setting the target width, height, and quality of the JPEG file.
        /// </summary>
        /// <param name="writeableBitmap">The WriteableBitmap object.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <param name="targetWidth">The target width of the file.</param>
        /// <param name="targetHeight">The target height of the file.</param>
        /// <param name="quality">This parameter represents the quality of the JPEG photo with a range between 0 and 100, with 100 being the best photo quality. We recommend that you do not fall lower than a value of 70. because JPEG picture quality diminishes significantly below that level. </param>
        public static void SaveJpeg(this WriteableBitmap writeableBitmap, Stream outputStream, int targetWidth, int targetHeight, int quality)
        {
            writeableBitmap.SaveJpeg(outputStream, targetWidth, targetHeight, 0, quality);
        }

        /// <summary>
        /// Encodes a WriteableBitmap object into a JPEG stream, with parameters for setting the target quality of the JPEG file.
        /// </summary>
        /// <param name="writeableBitmap">The WriteableBitmap object.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <param name="quality">This parameter represents the quality of the JPEG photo with a range between 0 and 100, with 100 being the best photo quality. We recommend that you do not fall lower than a value of 70. because JPEG picture quality diminishes significantly below that level. </param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task SaveJpegAsync(this WriteableBitmap writeableBitmap, Stream outputStream, int quality)
        {
            return writeableBitmap.SaveJpegAsync(outputStream, writeableBitmap.PixelWidth, writeableBitmap.PixelHeight, 0, quality);
        }

        /// <summary>
        /// Encodes a WriteableBitmap object into a JPEG stream, with parameters for setting the target width, height, and quality of the JPEG file.
        /// </summary>
        /// <param name="writeableBitmap">The WriteableBitmap object.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <param name="targetWidth">The target width of the file.</param>
        /// <param name="targetHeight">The target height of the file.</param>
        /// <param name="quality">This parameter represents the quality of the JPEG photo with a range between 0 and 100, with 100 being the best photo quality. We recommend that you do not fall lower than a value of 70. because JPEG picture quality diminishes significantly below that level. </param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task SaveJpegAsync(this WriteableBitmap writeableBitmap, Stream outputStream, int targetWidth, int targetHeight, int quality)
        {
            return writeableBitmap.SaveJpegAsync(outputStream, targetWidth, targetHeight, 0, quality);
        }

        /// <summary>
        /// Encodes a WriteableBitmap object into a JPEG stream, with parameters for setting the target width, height, orientation, and quality of the JPEG file.
        /// </summary>
        /// <param name="writeableBitmap">The WriteableBitmap object.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <param name="targetWidth">The target width of the file.</param>
        /// <param name="targetHeight">The target height of the file.</param>
        /// <param name="orientation">This parameter is not currently used by this method. Use a value of 0 as a placeholder.</param>
        /// <param name="quality">This parameter represents the quality of the JPEG photo with a range between 0 and 100, with 100 being the best photo quality. We recommend that you do not fall lower than a value of 70. because JPEG picture quality diminishes significantly below that level. </param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task SaveJpegAsync(this WriteableBitmap writeableBitmap, Stream outputStream, int targetWidth, int targetHeight, int orientation, int quality)
        {
            return Task.Factory.StartNew(() =>
            {
                writeableBitmap.SaveJpeg(outputStream, targetWidth, targetHeight, orientation, quality);
            });
        }

        private static void WriteHeader(Stream outputStream, Size desiredSize)
        {
            outputStream.Write(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, 0, 8);

            var chunkData = CreateChunk(
                (int)desiredSize.Width,
                (int)desiredSize.Height,
                PngHeaderBitDepth,
                PngHeaderColorType,
                PngHeaderCompressionMethod,
                PngHeaderFilterMethod,
                PngHeaderInterlaceMethod);

            WriteChunk(outputStream, PngChunkTypeHeader, chunkData);
        }

        private static void WritePhysics(Stream outputStream, WriteableBitmapSavePngParameters parameters)
        {
            if (parameters.SaveResolution)
            {
                var dpmX = (int)Math.Round(parameters.HorizontalResolution * MetreToInch);
                var dpmY = (int)Math.Round(parameters.VerticalResolution * MetreToInch);

                var chunkData = CreateChunk(dpmX, dpmY, (byte)1);

                WriteChunk(outputStream, PngChunkTypePhysical, chunkData);
            }
        }

        private static void WriteGamma(Stream outputStream, WriteableBitmapSavePngParameters parameters)
        {
            if (parameters.SaveGamma)
            {
                var gammaValue = (int)(parameters.Gamma * 100000f);

                var chunkData = CreateChunk(gammaValue);

                WriteChunk(outputStream, PngChunkTypeGamma, chunkData);
            }
        }

        private static void WriteDataChunks(Stream outputStream, WriteableBitmap writeableBitmap, WriteableBitmapSavePngParameters parameters, Size desiredSize)
        {
            using (var chunkedStream = new ChunkedStream(MaximumChunkSize, data => WriteChunk(outputStream, PngChunkTypeData, data)))
            {
                using (var zlibStream = new ZlibStream(chunkedStream, CompressionMode.Compress, parameters.CompressionLevel, true))
                {
                    var pixels = writeableBitmap.Pixels;
                    var width = (int)desiredSize.Width;
                    var height = (int)desiredSize.Height;
                    var index = 0;

                    var dataRowLength = width * 4;
                    var dataRow = new byte[dataRowLength];

                    for (var y = 0; y < height; y++)
                    {
                        // shift pixels due to on requested size
                        index = writeableBitmap.PixelWidth * y;
                        zlibStream.WriteByte(0);
                        for (var x = 0; x < width; x++)
                        {
                            var color = pixels[index++];
                            var alpha = (byte)(color >> 24);

                            int alphaInt = alpha;

                            if (alphaInt == 0)
                            {
                                alphaInt = 1;
                            }

                            alphaInt = (255 << 8) / alphaInt;

                            var dataRowOffset = x * 4;

                            dataRow[dataRowOffset] = (byte)((((color >> 16) & 0xFF) * alphaInt) >> 8);
                            dataRow[dataRowOffset + 1] = (byte)((((color >> 8) & 0xFF) * alphaInt) >> 8);
                            dataRow[dataRowOffset + 2] = (byte)(((color & 0xFF) * alphaInt) >> 8);
                            dataRow[dataRowOffset + 3] = alpha;
                        }

                        zlibStream.Write(dataRow, 0, dataRowLength);
                    }
                }
            }
        }

        private static void WriteFooter(Stream outputStream)
        {
            WriteChunk(outputStream, PngChunkTypeEnd, null);
        }

        private static void WriteChunk(Stream outputStream, string type, byte[] data)
        {
            var length = data != null ? data.Length : 0;

            outputStream.Write(CreateChunkFromInt(length), 0, 4);

            using (var crc32 = new CrcCalculatorStream(outputStream, true))
            {
                crc32.Write(CreateChunkFromString(type), 0, 4);

                if (data != null)
                {
                    crc32.Write(data, 0, length);
                }

                crc32.Flush();

                outputStream.Write(CreateChunkFromUint((uint)crc32.Crc), 0, 4);
            }
        }

        private static byte[] CreateChunk(params object[] paramObjects)
        {
            return paramObjects.SelectMany(x =>
            {
                if (x is byte)
                {
                    return new[] { (byte)x };
                }

                if (x is int)
                {
                    return CreateChunkFromInt((int)x);
                }

                if (x is uint)
                {
                    return CreateChunkFromUint((uint)x);
                }

                var stringValue = x as string;

                if (stringValue != null)
                {
                    return CreateChunkFromString(stringValue);
                }

                throw new ArgumentException();
            }).ToArray();
        }

        private static byte[] CreateChunkFromInt(int value)
        {
            var dataChunk = BitConverter.GetBytes(value);

            Array.Reverse(dataChunk);

            return dataChunk;
        }

        private static byte[] CreateChunkFromUint(uint value)
        {
            var dataChunk = BitConverter.GetBytes(value);

            Array.Reverse(dataChunk);

            return dataChunk;
        }

        private static byte[] CreateChunkFromString(string value)
        {
            return value
                .Select(x => (byte)x)
                .ToArray();
        }
    }
}