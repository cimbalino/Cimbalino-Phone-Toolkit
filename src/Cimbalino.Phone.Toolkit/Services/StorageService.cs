// ****************************************************************************
// <copyright file="StorageService.cs" company="Pedro Lamas">
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
using System.IO.IsolatedStorage;
using System.Text;
using Cimbalino.Phone.Toolkit.Extensions;
using Newtonsoft.Json;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IStorageService"/>.
    /// </summary>
    public class StorageService : IStorageService
    {
        /// <summary>
        /// Opens a binary file, reads the contents of the file into a byte array, and then closes the file. Returns null, if an exception is raised.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A byte array containing the contents of the file. Returns null, if an exception is raised.</returns>
        public byte[] Read(string path)
        {
            try
            {
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    return store.ReadAllBytes(path);
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string containing all lines of the file.</returns>
        public string ReadText(string path)
        {
            try
            {
                var data = Read(path);

                return Encoding.UTF8.GetString(data, 0, data.Length);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Opens a text file, deserializes an object from its JSON content, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>The deserialized object from the Json string.</returns>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        public T ReadObject<T>(string path) where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(ReadText(path));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="bytes">The bytes to write to the file.</param>
        public void Write(string path, byte[] bytes)
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var file = new IsolatedStorageFileStream(path, FileMode.Create, store))
                {
                    file.Write(bytes, 0, bytes.Length);

                    file.Flush();
                }
            }
        }

        /// <summary>
        /// Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        public void WriteText(string path, string contents)
        {
            Write(path, Encoding.UTF8.GetBytes(contents));
        }

        /// <summary>
        /// Creates a new file, writes the specified object serialized to JSON, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="data">The object to serialize.</param>
        /// <typeparam name="T">The type of the object to serialize from.</typeparam>
        public void WriteObject<T>(string path, T data) where T : class
        {
            WriteText(path, JsonConvert.SerializeObject(data));
        }
    }
}