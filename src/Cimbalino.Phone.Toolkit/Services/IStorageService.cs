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

using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the application storage
    /// </summary>
    public interface IStorageService
    {
        /// <summary>
        /// Gets a value that represents the amount of free space available for storage.
        /// </summary>
        /// <value>The available free storage space, in bytes.</value>
        long AvailableFreeSpace { get; }

        /// <summary>
        /// Gets a value that represents the maximum amount of space available for storage.
        /// </summary>
        /// <value>The limit of storage space, in bytes.</value>
        long Quota { get; }

        /// <summary>
        /// Copies an existing file to a new file.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to copy.</param>
        /// <param name="destinationFileName">The name of the destination file. This cannot be a directory or an existing file.</param>
        void CopyFile(string sourceFileName, string destinationFileName);

        /// <summary>
        /// Copies an existing file to a new file, and optionally overwrites an existing file.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to copy.</param>
        /// <param name="destinationFileName">The name of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite">true if the destination file can be overwritten; otherwise, false.</param>
        void CopyFile(string sourceFileName, string destinationFileName, bool overwrite);

        /// <summary>
        /// Creates a directory in the storage scope.
        /// </summary>
        /// <param name="dir">The relative path of the directory to create within the storage.</param>
        void CreateDirectory(string dir);

        /// <summary>
        /// Creates a file in the store.
        /// </summary>
        /// <param name="path">The relative path of the file to be created in the store.</param>
        /// <returns>A new storage file</returns>
        Stream CreateFile(string path);

        /// <summary>
        /// Deletes a directory in the storage scope.
        /// </summary>
        /// <param name="dir">The relative path of the directory to delete within the storage scope.</param>
        void DeleteDirectory(string dir);

        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        /// <param name="path">The name of the file to be deleted. Wildcard characters are not supported.</param>
        void DeleteFile(string path);

        /// <summary>
        /// Determines whether the specified path refers to an existing directory in the store.
        /// </summary>
        /// <param name="dir">The path to test.</param>
        /// <returns>true if path refers to an existing directory in the store and is not null; otherwise, false.</returns>
        bool DirectoryExists(string dir);

        /// <summary>
        /// Determines whether the specified path refers to an existing file in the store.
        /// </summary>
        /// <param name="path">The path and file name to test.</param>
        /// <returns>true if path refers to an existing file in the store and is not null; otherwise, false.</returns>
        bool FileExists(string path);

        /// <summary>
        /// Enumerates the directories in the root of a store.
        /// </summary>
        /// <returns>An <see cref="System.Array"/> of relative paths of directories in the root of the store. A zero-length array specifies that there are no directories in the root.</returns>
        string[] GetDirectoryNames();

        /// <summary>
        /// Enumerates directories in a storage scope that match a given pattern.
        /// </summary>
        /// <param name="searchPattern">A search pattern. Both single-character ("?") and multi-character ("*") wildcards are supported.</param>
        /// <returns>An <see cref="System.Array"/> of the relative paths of directories in the storage scope that match searchPattern. A zero-length array specifies that there are no directories that match.</returns>
        string[] GetDirectoryNames(string searchPattern);

        /// <summary>
        /// Obtains the names of files in the root of a store.
        /// </summary>
        /// <returns>An <see cref="System.Array"/> of relative paths of files in the root of the store. A zero-length array specifies that there are no files in the root.</returns>
        string[] GetFileNames();

        /// <summary>
        /// Enumerates files in storage scope that match a given pattern.
        /// </summary>
        /// <param name="searchPattern">A search pattern. Both single-character ("?") and multi-character ("*") wildcards are supported.</param>
        /// <returns>An <see cref="System.Array"/> of relative paths of files in the storage scope that match searchPattern. A zero-length array specifies that there are no files that match.</returns>
        string[] GetFileNames(string searchPattern);

        /// <summary>
        /// Enables an application to explicitly request a larger quota size, in bytes
        /// </summary>
        /// <param name="newQuotaSize">The requested size, in bytes.</param>
        /// <returns>true if the new quota is accepted by the user, otherwise, false.</returns>
        bool IncreaseQuotaTo(long newQuotaSize);

        /// <summary>
        /// Moves a specified directory and its contents to a new location.
        /// </summary>
        /// <param name="sourceDirectoryName">The name of the directory to move.</param>
        /// <param name="destinationDirectoryName">The path to the new location for sourceDirectoryName. This cannot be the path to an existing directory.</param>
        void MoveDirectory(string sourceDirectoryName, string destinationDirectoryName);

        /// <summary>
        /// Moves a specified file to a new location, and optionally lets you specify a new file name.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to move.</param>
        /// <param name="destinationFileName">The path to the new location for the file. If a file name is included, the moved file will have that name.</param>
        void MoveFile(string sourceFileName, string destinationFileName);

        /// <summary>
        /// Opens a file in the specified mode.
        /// </summary>
        /// <param name="path">The relative path of the file within the store.</param>
        /// <param name="mode">The mode in which to open the file.</param>
        /// <returns>A file that is opened in the specified mode, with read/write access, and is unshared.</returns>
        Stream OpenFile(string path, FileMode mode);

        /// <summary>
        /// Opens a file in the specified mode with the specified file access.
        /// </summary>
        /// <param name="path">The relative path of the file within the store.</param>
        /// <param name="mode">The mode in which to open the file.</param>
        /// <param name="access">The type of access to open the file with.</param>
        /// <returns>A file that is opened in the specified mode and access, and is unshared.</returns>
        Stream OpenFile(string path, FileMode mode, FileAccess access);

        /// <summary>
        /// Opens a file in the specified mode with read, write, or read/write access and the specified sharing option.
        /// </summary>
        /// <param name="path">The relative path of the file within the store.</param>
        /// <param name="mode">The mode in which to open the file.</param>
        /// <param name="access">The type of access to open the file with.</param>
        /// <param name="share">The type of access other <see cref="Stream"/> objects have to this file.</param>
        /// <returns>A file that is opened in the specified mode and access, and with the specified sharing options.</returns>
        Stream OpenFile(string path, FileMode mode, FileAccess access, FileShare share);

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string containing all lines of the file.</returns>
        string ReadAllText(string path);

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>A string containing all lines of the file.</returns>
        string ReadAllText(string path, Encoding encoding);

        /// <summary>
        /// Reads the lines of a file.
        /// </summary>
        /// <param name="path">The file to read.</param>
        /// <returns>The lines of the file.</returns>
        IEnumerable<string> ReadLines(string path);

        /// <summary>
        /// Reads the lines of a file that has a specified encoding.
        /// </summary>
        /// <param name="path">The file to read.</param>
        /// <param name="encoding">The encoding that is applied to the contents of the file.</param>
        /// <returns>The lines of the file.</returns>
        IEnumerable<string> ReadLines(string path, Encoding encoding);

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string array containing all lines of the file.</returns>
        string[] ReadAllLines(string path);

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>A string array containing all lines of the file.</returns>
        string[] ReadAllLines(string path, Encoding encoding);

        /// <summary>
        /// Opens a binary file, reads the contents of the file into a byte array, and then closes the file. Returns null, if an exception is raised.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A byte array containing the contents of the file. Returns null, if an exception is raised.</returns>
        byte[] ReadAllBytes(string path);

        /// <summary>
        /// Opens a text file, deserializes an object from its JSON content, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>The deserialized object from the Json string.</returns>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        T ReadObject<T>(string path) where T : class;

        /// <summary>
        /// Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        void WriteAllText(string path, string contents);

        /// <summary>
        /// Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        void WriteAllText(string path, string contents, Encoding encoding);

        /// <summary>
        /// Creates a new file, writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        void WriteAllLines(string path, IEnumerable<string> contents);

        /// <summary>
        /// Creates a new file by using the specified encoding, writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding);

        /// <summary>
        /// Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="bytes">The bytes to write to the file.</param>
        void WriteAllBytes(string path, byte[] bytes);

        /// <summary>
        /// Creates a new file, writes the specified object serialized to JSON, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="data">The object to serialize.</param>
        /// <typeparam name="T">The type of the object to serialize from.</typeparam>
        void WriteObject<T>(string path, T data) where T : class;

        /// <summary>
        /// Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        void AppendAllText(string path, string contents);

        /// <summary>
        /// Appends the specified string to the file, creating the file if it does not already exist.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        void AppendAllText(string path, string contents, Encoding encoding);

        /// <summary>
        /// Appends lines to a file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it does not already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        void AppendAllLines(string path, IEnumerable<string> contents);

        /// <summary>
        /// Appends lines to a file by using a specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it does not already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding);
    }
}