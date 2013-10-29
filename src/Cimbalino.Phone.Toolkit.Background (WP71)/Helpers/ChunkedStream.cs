// ****************************************************************************
// <copyright file="ChunkedStream.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>23-04-2013</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.IO;

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Creates a stream that helps dividing data in fixed size chunks.
    /// </summary>
    public class ChunkedStream : Stream
    {
        private readonly MemoryStream _memoryStream = new MemoryStream();

        private readonly int _chunkSize;
        private readonly Action<byte[]> _chunkReadyAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChunkedStream"/> class.
        /// </summary>
        /// <param name="chunkSize">The chunk size.</param>
        /// <param name="chunkReadyAction">The <see cref="Action"/> to perform when a chunk is ready.</param>
        public ChunkedStream(int chunkSize, Action<byte[]> chunkReadyAction)
        {
            _chunkSize = chunkSize;
            _chunkReadyAction = chunkReadyAction;
        }

        /// <summary>
        /// Overrides <see cref="Stream.Flush"/> so that no action is performed.
        /// </summary>
        public override void Flush()
        {
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        /// <returns>Calling this method will raise a <see cref="NotSupportedException"/>.</returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="origin">The origin.</param>
        /// <returns>Calling this method will raise a <see cref="NotSupportedException"/>.</returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="value">The value.</param>
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Writes a block of bytes to the current stream using data read from a buffer.
        /// </summary>
        /// <param name="buffer">The buffer to write data from.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The maximum number of bytes to write.</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            _memoryStream.Write(buffer, offset, count);

            if (_memoryStream.Position >= _chunkSize)
            {
                SendChunks();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading.
        /// </summary>
        /// <value>Always false as <see cref="ChunkedStream"/> doesn't support reading.</value>
        public override bool CanRead
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking.
        /// </summary>
        /// <value>Always false as <see cref="ChunkedStream"/> doesn't support seeking.</value>
        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing.
        /// </summary>
        /// <value>true if the stream supports writing; otherwise, false.</value>
        public override bool CanWrite
        {
            get
            {
                return _memoryStream.CanWrite;
            }
        }

        /// <summary>
        /// This property is not supported.
        /// </summary>
        /// <value>The length.</value>
        public override long Length
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// This property is not supported.
        /// </summary>
        /// <value>The position.</value>
        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Closes the current stream and releases all resources.
        /// </summary>
        public override void Close()
        {
            if (_memoryStream.Position > 0)
            {
                SendChunks();
            }

            _memoryStream.Close();

            base.Close();
        }

        private void SendChunks()
        {
            var buffer = _memoryStream.GetBuffer();
            var currentPosition = _memoryStream.Position;
            var workPosition = 0;
            var nextWorkPosition = _chunkSize;

            while (true)
            {
                var workBufferSize = nextWorkPosition > currentPosition ? currentPosition - workPosition : _chunkSize;

                var workBuffer = new byte[workBufferSize];

                Buffer.BlockCopy(buffer, workPosition, workBuffer, 0, (int)workBufferSize);

                _chunkReadyAction(workBuffer);

                workPosition = nextWorkPosition;

                nextWorkPosition += _chunkSize;

                if (nextWorkPosition > currentPosition)
                {
                    break;
                }
            }

            if (workPosition == currentPosition)
            {
                _memoryStream.Position = 0;
            }
            else if (workPosition < currentPosition)
            {
                Buffer.BlockCopy(buffer, workPosition, buffer, 0, (int)(currentPosition - workPosition));

                _memoryStream.Position = currentPosition - workPosition;
            }
        }
    }
}