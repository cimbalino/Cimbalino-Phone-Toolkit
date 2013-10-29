// ****************************************************************************
// <copyright file="IsolatedStorageFileExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-11-2011</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="IsolatedStorageFile"/> instances.
    /// </summary>
    public static class IsolatedStorageFileExtensions
    {
        private static readonly UTF8Encoding _uft8NoBOM = new UTF8Encoding(false, true);

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string containing all lines of the file.</returns>
        public static string ReadAllText(this IsolatedStorageFile store, string path)
        {
            return store.ReadAllText(path, Encoding.UTF8);
        }

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>A string containing all lines of the file.</returns>
        public static string ReadAllText(this IsolatedStorageFile store, string path, Encoding encoding)
        {
            using (var streamReader = new StreamReader(store.OpenFile(path, FileMode.Open), encoding))
            {
                return streamReader.ReadToEnd();
            }
        }

        /// <summary>
        /// Reads the lines of a file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to read.</param>
        /// <returns>The lines of the file.</returns>
        public static IEnumerable<string> ReadLines(this IsolatedStorageFile store, string path)
        {
            return store.ReadLines(path, Encoding.UTF8);
        }

        /// <summary>
        /// Reads the lines of a file that has a specified encoding.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to read.</param>
        /// <param name="encoding">The encoding that is applied to the contents of the file.</param>
        /// <returns>The lines of the file.</returns>
        public static IEnumerable<string> ReadLines(this IsolatedStorageFile store, string path, Encoding encoding)
        {
            using (var streamReader = new StreamReader(store.OpenFile(path, FileMode.Open), encoding))
            {
                string textLine;

                while ((textLine = streamReader.ReadLine()) != null)
                {
                    yield return textLine;
                }
            }
        }

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string array containing all lines of the file.</returns>
        public static string[] ReadAllLines(this IsolatedStorageFile store, string path)
        {
            return store.ReadAllLines(path, Encoding.UTF8);
        }

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>A string array containing all lines of the file.</returns>
        public static string[] ReadAllLines(this IsolatedStorageFile store, string path, Encoding encoding)
        {
            return store.ReadLines(path, encoding).ToArray();
        }

        /// <summary>
        /// Opens a binary file, reads the contents of the file into a byte array, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A byte array containing the contents of the file.</returns>
        public static byte[] ReadAllBytes(this IsolatedStorageFile store, string path)
        {
            using (var fileStream = store.OpenFile(path, FileMode.Open))
            {
                var buffer = new byte[fileStream.Length];

                fileStream.Read(buffer, 0, buffer.Length);

                return buffer;
            }
        }

        /// <summary>
        /// Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        public static void WriteAllText(this IsolatedStorageFile store, string path, string contents)
        {
            store.WriteAllText(path, contents, _uft8NoBOM);
        }

        /// <summary>
        /// Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        public static void WriteAllText(this IsolatedStorageFile store, string path, string contents, Encoding encoding)
        {
            InternalWriteAllText(store.OpenFile(path, FileMode.Create), contents, encoding);
        }

        /// <summary>
        /// Creates a new file, writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        public static void WriteAllLines(this IsolatedStorageFile store, string path, IEnumerable<string> contents)
        {
            store.WriteAllLines(path, contents, _uft8NoBOM);
        }

        /// <summary>
        /// Creates a new file by using the specified encoding, writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        public static void WriteAllLines(this IsolatedStorageFile store, string path, IEnumerable<string> contents, Encoding encoding)
        {
            InternalWriteAllLines(store.OpenFile(path, FileMode.Create), contents, encoding);
        }

        /// <summary>
        /// Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten..
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to write to.</param>
        /// <param name="bytes">The bytes to write to the file.</param>
        public static void WriteAllBytes(this IsolatedStorageFile store, string path, byte[] bytes)
        {
            using (var fileStream = store.OpenFile(path, FileMode.Create))
            {
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }

        /// <summary>
        /// Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        public static void AppendAllText(this IsolatedStorageFile store, string path, string contents)
        {
            store.AppendAllText(path, contents, _uft8NoBOM);
        }

        /// <summary>
        /// Appends the specified string to the file, creating the file if it does not already exist.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        public static void AppendAllText(this IsolatedStorageFile store, string path, string contents, Encoding encoding)
        {
            InternalWriteAllText(store.OpenFile(path, FileMode.OpenOrCreate), contents, encoding);
        }

        /// <summary>
        /// Appends lines to a file, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to append the lines to. The file is created if it does not already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        public static void AppendAllLines(this IsolatedStorageFile store, string path, IEnumerable<string> contents)
        {
            store.AppendAllLines(path, contents, _uft8NoBOM);
        }

        /// <summary>
        /// Appends lines to a file by using a specified encoding, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to append the lines to. The file is created if it does not already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        public static void AppendAllLines(this IsolatedStorageFile store, string path, IEnumerable<string> contents, Encoding encoding)
        {
            InternalWriteAllLines(store.OpenFile(path, FileMode.OpenOrCreate), contents, encoding);
        }

        /// <summary>
        /// Deletes the specified directory and, if indicated, any subdirectories and files in the directory.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The relative path of the directory to delete within the isolated storage scope.</param>
        /// <param name="recursive">true to remove directories, subdirectories, and files in path; otherwise, false.</param>
        public static void DeleteDirectory(this IsolatedStorageFile store, string path, bool recursive)
        {
            if (!store.DirectoryExists(path))
            {
                return;
            }

            if (recursive)
            {
                foreach (var folder in store.GetDirectoryNames(Path.Combine(path, "*.*")))
                {
                    store.DeleteDirectory(Path.Combine(path, folder), true);
                }

                foreach (var file in store.GetFileNames(Path.Combine(path, "*.*")))
                {
                    store.DeleteFile(Path.Combine(path, file));
                }
            }

            store.DeleteDirectory(path);
        }

        private static void InternalWriteAllLines(IsolatedStorageFileStream fileStream, IEnumerable<string> contents, Encoding encoding)
        {
            using (var streamWriter = new StreamWriter(fileStream, encoding))
            {
                foreach (var str in contents)
                {
                    streamWriter.WriteLine(str);
                }
            }
        }

        private static void InternalWriteAllText(IsolatedStorageFileStream fileStream, string contents, Encoding encoding)
        {
            using (var streamWriter = new StreamWriter(fileStream, encoding))
            {
                streamWriter.WriteLine(contents);
            }
        }

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task<string> ReadAllTextAsync(this IsolatedStorageFile store, string path)
        {
            return store.ReadAllTextAsync(path, Encoding.UTF8);
        }

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task<string> ReadAllTextAsync(this IsolatedStorageFile store, string path, Encoding encoding)
        {
            using (var streamReader = new StreamReader(store.OpenFile(path, FileMode.Open), encoding))
            {
                return streamReader.ReadToEndAsync();
            }
        }

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task<string[]> ReadAllLinesAsync(this IsolatedStorageFile store, string path)
        {
            return store.ReadAllLinesAsync(path, Encoding.UTF8);
        }

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>A string array containing all lines of the file.</returns>
        public static Task<string[]> ReadAllLinesAsync(this IsolatedStorageFile store, string path, Encoding encoding)
        {
            using (var streamReader = new StreamReader(store.OpenFile(path, FileMode.Open), encoding))
            {
                return streamReader.ReadAllLinesAsync();
            }
        }

        /// <summary>
        /// Opens a binary file, reads the contents of the file into a byte array, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async static Task<byte[]> ReadAllBytesAsync(this IsolatedStorageFile store, string path)
        {
            using (var fileStream = store.OpenFile(path, FileMode.Open))
            {
                var buffer = new byte[fileStream.Length];

                await fileStream.ReadAsync(buffer, 0, buffer.Length);

                return buffer;
            }
        }

        /// <summary>
        /// Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task WriteAllTextAsync(this IsolatedStorageFile store, string path, string contents)
        {
            return store.WriteAllTextAsync(path, contents, _uft8NoBOM);
        }

        /// <summary>
        /// Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task WriteAllTextAsync(this IsolatedStorageFile store, string path, string contents, Encoding encoding)
        {
            return InternalWriteAllTextAsync(store.OpenFile(path, FileMode.Create), contents, encoding);
        }

        /// <summary>
        /// Creates a new file, writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task WriteAllLinesAsync(this IsolatedStorageFile store, string path, IEnumerable<string> contents)
        {
            return store.WriteAllLinesAsync(path, contents, _uft8NoBOM);
        }

        /// <summary>
        /// Creates a new file by using the specified encoding, writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task WriteAllLinesAsync(this IsolatedStorageFile store, string path, IEnumerable<string> contents, Encoding encoding)
        {
            return InternalWriteAllLinesAsync(store.OpenFile(path, FileMode.Create), contents, encoding);
        }

        /// <summary>
        /// Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten..
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to write to.</param>
        /// <param name="bytes">The bytes to write to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task WriteAllBytesAsync(this IsolatedStorageFile store, string path, byte[] bytes)
        {
            using (var fileStream = store.OpenFile(path, FileMode.Create))
            {
                return fileStream.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        /// <summary>
        /// Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task AppendAllTextAsync(this IsolatedStorageFile store, string path, string contents)
        {
            return store.AppendAllTextAsync(path, contents, _uft8NoBOM);
        }

        /// <summary>
        /// Appends the specified string to the file, creating the file if it does not already exist.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task AppendAllTextAsync(this IsolatedStorageFile store, string path, string contents, Encoding encoding)
        {
            return InternalWriteAllTextAsync(store.OpenFile(path, FileMode.OpenOrCreate), contents, encoding);
        }

        /// <summary>
        /// Appends lines to a file, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to append the lines to. The file is created if it does not already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task AppendAllLinesAsync(this IsolatedStorageFile store, string path, IEnumerable<string> contents)
        {
            return store.AppendAllLinesAsync(path, contents, _uft8NoBOM);
        }

        /// <summary>
        /// Appends lines to a file by using a specified encoding, and then closes the file.
        /// </summary>
        /// <param name="store">The <see cref="IsolatedStorageFile"/> object.</param>
        /// <param name="path">The file to append the lines to. The file is created if it does not already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task AppendAllLinesAsync(this IsolatedStorageFile store, string path, IEnumerable<string> contents, Encoding encoding)
        {
            return InternalWriteAllLinesAsync(store.OpenFile(path, FileMode.OpenOrCreate), contents, encoding);
        }

        private async static Task InternalWriteAllLinesAsync(IsolatedStorageFileStream fileStream, IEnumerable<string> contents, Encoding encoding)
        {
            using (var streamWriter = new StreamWriter(fileStream, encoding))
            {
                foreach (var str in contents)
                {
                    await streamWriter.WriteLineAsync(str);
                }
            }
        }

        private static Task InternalWriteAllTextAsync(IsolatedStorageFileStream fileStream, string contents, Encoding encoding)
        {
            using (var streamWriter = new StreamWriter(fileStream, encoding))
            {
                return streamWriter.WriteLineAsync(contents);
            }
        }
    }
}