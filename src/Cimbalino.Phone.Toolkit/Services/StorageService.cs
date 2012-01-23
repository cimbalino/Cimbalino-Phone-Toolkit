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

using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using Cimbalino.Phone.Toolkit.Extensions;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IStorageService"/>.
    /// </summary>
    public class StorageService : IStorageService
    {
        private readonly IsolatedStorageFile _store = IsolatedStorageFile.GetUserStoreForApplication();

        /// <summary>
        /// Gets a value that represents the amount of free space available for storage.
        /// </summary>
        /// <value>The available free storage space, in bytes.</value>
        public long AvailableFreeSpace
        {
            get
            {
                return _store.AvailableFreeSpace;
            }
        }

        /// <summary>
        /// Gets a value that represents the maximum amount of space available for storage.
        /// </summary>
        /// <value>The limit of storage space, in bytes.</value>
        public long Quota
        {
            get
            {
                return _store.Quota;
            }
        }

        /// <summary>
        /// Copies an existing file to a new file.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to copy.</param>
        /// <param name="destinationFileName">The name of the destination file. This cannot be a directory or an existing file.</param>
        public void CopyFile(string sourceFileName, string destinationFileName)
        {
            _store.CopyFile(sourceFileName, destinationFileName);
        }

        /// <summary>
        /// Copies an existing file to a new file, and optionally overwrites an existing file.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to copy.</param>
        /// <param name="destinationFileName">The name of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite">true if the destination file can be overwritten; otherwise, false.</param>
        public void CopyFile(string sourceFileName, string destinationFileName, bool overwrite)
        {
            _store.CopyFile(sourceFileName, destinationFileName, overwrite);
        }

        /// <summary>
        /// Creates a directory in the storage scope.
        /// </summary>
        /// <param name="dir">The relative path of the directory to create within the storage.</param>
        public void CreateDirectory(string dir)
        {
            _store.CreateDirectory(dir);
        }

        /// <summary>
        /// Creates a file in the store.
        /// </summary>
        /// <param name="path">The relative path of the file to be created in the store.</param>
        /// <returns>A new storage file</returns>
        public Stream CreateFile(string path)
        {
            return _store.CreateFile(path);
        }

        /// <summary>
        /// Deletes a directory in the storage scope.
        /// </summary>
        /// <param name="dir">The relative path of the directory to delete within the storage scope.</param>
        public void DeleteDirectory(string dir)
        {
            _store.DeleteDirectory(dir);
        }

        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        /// <param name="path">The name of the file to be deleted. Wildcard characters are not supported.</param>
        public void DeleteFile(string path)
        {
            _store.DeleteFile(path);
        }

        /// <summary>
        /// Determines whether the specified path refers to an existing directory in the store.
        /// </summary>
        /// <param name="dir">The path to test.</param>
        /// <returns>
        /// true if path refers to an existing directory in the store and is not null; otherwise, false.
        /// </returns>
        public bool DirectoryExists(string dir)
        {
            return _store.DirectoryExists(dir);
        }

        /// <summary>
        /// Determines whether the specified path refers to an existing file in the store.
        /// </summary>
        /// <param name="path">The path and file name to test.</param>
        /// <returns>
        /// true if path refers to an existing file in the store and is not null; otherwise, false.
        /// </returns>
        public bool FileExists(string path)
        {
            return _store.FileExists(path);
        }

        /// <summary>
        /// Enumerates the directories in the root of a store.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Array" /> of relative paths of directories in the root of the store. A zero-length array specifies that there are no directories in the root.
        /// </returns>
        public string[] GetDirectoryNames()
        {
            return _store.GetDirectoryNames();
        }

        /// <summary>
        /// Enumerates directories in a storage scope that match a given pattern.
        /// </summary>
        /// <param name="searchPattern">A search pattern. Both single-character ("?") and multi-character ("*") wildcards are supported.</param>
        /// <returns>
        /// An <see cref="System.Array" /> of the relative paths of directories in the storage scope that match searchPattern. A zero-length array specifies that there are no directories that match.
        /// </returns>
        public string[] GetDirectoryNames(string searchPattern)
        {
            return _store.GetDirectoryNames(searchPattern);
        }

        /// <summary>
        /// Obtains the names of files in the root of a store.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Array" /> of relative paths of files in the root of the store. A zero-length array specifies that there are no files in the root.
        /// </returns>
        public string[] GetFileNames()
        {
            return _store.GetFileNames();
        }

        /// <summary>
        /// Enumerates files in storage scope that match a given pattern.
        /// </summary>
        /// <param name="searchPattern">A search pattern. Both single-character ("?") and multi-character ("*") wildcards are supported.</param>
        /// <returns>
        /// An <see cref="System.Array" /> of relative paths of files in the storage scope that match searchPattern. A zero-length array specifies that there are no files that match.
        /// </returns>
        public string[] GetFileNames(string searchPattern)
        {
            return _store.GetFileNames(searchPattern);
        }

        /// <summary>
        /// Enables an application to explicitly request a larger quota size, in bytes
        /// </summary>
        /// <param name="newQuotaSize">The requested size, in bytes.</param>
        /// <returns>true if the new quota is accepted by the user, otherwise, false.</returns>
        public bool IncreaseQuotaTo(long newQuotaSize)
        {
            return _store.IncreaseQuotaTo(newQuotaSize);
        }

        /// <summary>
        /// Moves a specified directory and its contents to a new location.
        /// </summary>
        /// <param name="sourceDirectoryName">The name of the directory to move.</param>
        /// <param name="destinationDirectoryName">The path to the new location for sourceDirectoryName. This cannot be the path to an existing directory.</param>
        public void MoveDirectory(string sourceDirectoryName, string destinationDirectoryName)
        {
            _store.MoveDirectory(sourceDirectoryName, destinationDirectoryName);
        }

        /// <summary>
        /// Moves a specified file to a new location, and optionally lets you specify a new file name.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to move.</param>
        /// <param name="destinationFileName">The path to the new location for the file. If a file name is included, the moved file will have that name.</param>
        public void MoveFile(string sourceFileName, string destinationFileName)
        {
            _store.MoveFile(sourceFileName, destinationFileName);
        }

        /// <summary>
        /// Opens a file in the specified mode.
        /// </summary>
        /// <param name="path">The relative path of the file within the store.</param>
        /// <param name="mode">The mode in which to open the file.</param>
        /// <returns>
        /// A file that is opened in the specified mode, with read/write access, and is unshared.
        /// </returns>
        public Stream OpenFile(string path, FileMode mode)
        {
            return _store.OpenFile(path, mode);
        }

        /// <summary>
        /// Opens a file in the specified mode with the specified file access.
        /// </summary>
        /// <param name="path">The relative path of the file within the store.</param>
        /// <param name="mode">The mode in which to open the file.</param>
        /// <param name="access">The type of access to open the file with.</param>
        /// <returns>
        /// A file that is opened in the specified mode and access, and is unshared.
        /// </returns>
        public Stream OpenFile(string path, FileMode mode, FileAccess access)
        {
            return _store.OpenFile(path, mode, access);
        }

        /// <summary>
        /// Opens a file in the specified mode with read, write, or read/write access and the specified sharing option.
        /// </summary>
        /// <param name="path">The relative path of the file within the store.</param>
        /// <param name="mode">The mode in which to open the file.</param>
        /// <param name="access">The type of access to open the file with.</param>
        /// <param name="share">The type of access other <see cref="Stream" /> objects have to this file.</param>
        /// <returns>
        /// A file that is opened in the specified mode and access, and with the specified sharing options.
        /// </returns>
        public Stream OpenFile(string path, FileMode mode, FileAccess access, FileShare share)
        {
            return _store.OpenFile(path, mode, access, share);
        }

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string containing all lines of the file.</returns>
        public string ReadAllText(string path)
        {
            return _store.ReadAllText(path);
        }

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>A string containing all lines of the file.</returns>
        public string ReadAllText(string path, Encoding encoding)
        {
            return _store.ReadAllText(path, encoding);
        }

        /// <summary>
        /// Reads the lines of a file.
        /// </summary>
        /// <param name="path">The file to read.</param>
        /// <returns>The lines of the file.</returns>
        public IEnumerable<string> ReadLines(string path)
        {
            return _store.ReadLines(path);
        }

        /// <summary>
        /// Reads the lines of a file that has a specified encoding.
        /// </summary>
        /// <param name="path">The file to read.</param>
        /// <param name="encoding">The encoding that is applied to the contents of the file.</param>
        /// <returns>The lines of the file.</returns>
        public IEnumerable<string> ReadLines(string path, Encoding encoding)
        {
            return _store.ReadLines(path, encoding);
        }

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string array containing all lines of the file.</returns>
        public string[] ReadAllLines(string path)
        {
            return _store.ReadAllLines(path);
        }

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>A string array containing all lines of the file.</returns>
        public string[] ReadAllLines(string path, Encoding encoding)
        {
            return _store.ReadAllLines(path, encoding);
        }

        /// <summary>
        /// Opens a binary file, reads the contents of the file into a byte array, and then closes the file. Returns null, if an exception is raised.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>
        /// A byte array containing the contents of the file. Returns null, if an exception is raised.
        /// </returns>
        public byte[] ReadAllBytes(string path)
        {
            return _store.ReadAllBytes(path);
        }

        /// <summary>
        /// Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        public void WriteAllText(string path, string contents)
        {
            _store.WriteAllText(path, contents);
        }

        /// <summary>
        /// Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        public void WriteAllText(string path, string contents, Encoding encoding)
        {
            _store.WriteAllText(path, contents, encoding);
        }

        /// <summary>
        /// Creates a new file, writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        public void WriteAllLines(string path, IEnumerable<string> contents)
        {
            _store.WriteAllLines(path, contents);
        }

        /// <summary>
        /// Creates a new file by using the specified encoding, writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        public void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            _store.WriteAllLines(path, contents, encoding);
        }

        /// <summary>
        /// Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="bytes">The bytes to write to the file.</param>
        public void WriteAllBytes(string path, byte[] bytes)
        {
            _store.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        public void AppendAllText(string path, string contents)
        {
            _store.AppendAllText(path, contents);
        }

        /// <summary>
        /// Appends the specified string to the file, creating the file if it does not already exist.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        public void AppendAllText(string path, string contents, Encoding encoding)
        {
            _store.AppendAllText(path, contents, encoding);
        }

        /// <summary>
        /// Appends lines to a file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it does not already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        public void AppendAllLines(string path, IEnumerable<string> contents)
        {
            _store.AppendAllLines(path, contents);
        }

        /// <summary>
        /// Appends lines to a file by using a specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it does not already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        public void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            _store.AppendAllLines(path, contents, encoding);
        }
    }
}