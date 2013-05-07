// ****************************************************************************
// <copyright file="StreamExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="Stream"/> instances.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Writes the stream contents to a byte array.
        /// </summary>
        /// <param name="input">The input stream.</param>
        /// <returns>A new byte array.</returns>
        public static byte[] ToArray(this Stream input)
        {
            using (var memoryStream = new MemoryStream())
            {
                input.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Computes the <see cref="SHA1"/> hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">The input <see cref="Stream"/> to compute the hash code for.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeSHA1Hash(this Stream input)
        {
            using (var hash = new SHA1Managed())
            {
                return hash.ComputeHash(input);
            }
        }

        /// <summary>
        /// Computes the <see cref="SHA256"/> hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">The input <see cref="Stream"/> to compute the hash code for.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeSHA256Hash(this Stream input)
        {
            using (var hash = new SHA256Managed())
            {
                return hash.ComputeHash(input);
            }
        }

        /// <summary>
        /// Computes the <see cref="HMACSHA1"/> hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">The input <see cref="Stream"/> to compute the hash code for.</param>
        /// <param name="key">The key to use in the hash algorithm.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHMACSHA1Hash(this Stream input, byte[] key)
        {
            using (var hash = new HMACSHA1())
            {
                hash.Key = key;

                return hash.ComputeHash(input);
            }
        }

        /// <summary>
        /// Computes the <see cref="SHA256"/> hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">The input <see cref="Stream"/> to compute the hash code for.</param>
        /// <param name="key">The key to use in the hash algorithm.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHMACSHA256Hash(this Stream input, byte[] key)
        {
            using (var hash = new HMACSHA256())
            {
                hash.Key = key;

                return hash.ComputeHash(input);
            }
        }

        /// <summary>
        /// Writes the stream contents to a byte array.
        /// </summary>
        /// <param name="input">The input stream.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static async Task<byte[]> ToArrayAsync(this Stream input)
        {
            var memoryStream = input as MemoryStream;

            if (memoryStream != null)
            {
                return memoryStream.ToArray();
            }

            using (memoryStream = new MemoryStream())
            {
                await input.CopyToAsync(memoryStream);

                return memoryStream.ToArray();
            }
        }
    }
}