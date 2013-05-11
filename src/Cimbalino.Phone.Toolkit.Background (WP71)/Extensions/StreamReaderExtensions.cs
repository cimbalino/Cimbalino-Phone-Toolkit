// ****************************************************************************
// <copyright file="StreamReaderExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>07-12-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="StreamReader"/> instances.
    /// </summary>
    public static class StreamReaderExtensions
    {
        /// <summary>
        /// Reads the lines of a stream.
        /// </summary>
        /// <param name="streamReader">The <see cref="StreamReader"/> instance.</param>
        /// <returns>The lines of the stream.</returns>
        public static IEnumerable<string> ReadLines(this StreamReader streamReader)
        {
            while (!streamReader.EndOfStream)
            {
                yield return streamReader.ReadLine();
            }
        }

        /// <summary>
        /// Reads all lines of the stream.
        /// </summary>
        /// <param name="streamReader">The <see cref="StreamReader"/> instance.</param>
        /// <returns>A string array containing all lines of the stream.</returns>
        public static string[] ReadAllLines(this StreamReader streamReader)
        {
            return streamReader.ReadLines().ToArray();
        }
    }
}