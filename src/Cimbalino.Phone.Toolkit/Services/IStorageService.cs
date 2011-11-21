// ****************************************************************************
// <copyright file="IStorageService.cs" company="Pedro Lamas">
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

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the application isolated storage
    /// </summary>
    public interface IStorageService
    {
        /// <summary>
        /// Opens a binary file, reads the contents of the file into a byte array, and then closes the file. Returns null, if an exception is raised.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A byte array containing the contents of the file. Returns null, if an exception is raised.</returns>
        byte[] Read(string path);

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string containing all lines of the file.</returns>
        string ReadText(string path);

        /// <summary>
        /// Opens a text file, deserializes an object from its JSON content, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>The deserialized object from the Json string.</returns>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        T ReadObject<T>(string path) where T : class;

        /// <summary>
        /// Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="bytes">The bytes to write to the file.</param>
        void Write(string path, byte[] bytes);

        /// <summary>
        /// Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        void WriteText(string path, string contents);

        /// <summary>
        /// Creates a new file, writes the specified object serialized to JSON, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="data">The object to serialize.</param>
        /// <typeparam name="T">The type of the object to serialize from.</typeparam>
        void WriteObject<T>(string path, T data) where T : class;
    }
}