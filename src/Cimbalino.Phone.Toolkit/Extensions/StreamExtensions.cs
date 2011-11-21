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

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="System.IO.Stream"/> instances
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Reads all the bytes from the current stream and writes them to a destination stream.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="destination">The destination.</param>
        public static void CopyTo(this Stream input, Stream destination)
        {
            int num;
            var buffer = new byte[0x1000];

            while ((num = input.Read(buffer, 0, buffer.Length)) != 0)
            {
                destination.Write(buffer, 0, num);
            }
        }
    }
}