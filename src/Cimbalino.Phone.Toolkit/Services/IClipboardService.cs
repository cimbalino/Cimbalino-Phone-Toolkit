// ****************************************************************************
// <copyright file="IClipboardService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>26-12-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Security;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of transferring data to the system clipboard.
    /// </summary>
    public interface IClipboardService
    {
        /// <summary>
        /// Sets Unicode text data to store on the clipboard.
        /// </summary>
        /// <param name="text">A string that contains the Unicode text data to store on the clipboard.</param>
        /// <exception cref="SecurityException">Invoked this method from outside a user-initiated context -or- Clipboard access user dialog box was not confirmed.</exception>
        void SetText(string text);

        /// <summary>
        /// Queries the clipboard for the presence of data in the UnicodeText format.
        /// </summary>
        /// <returns>true if the system clipboard contains Unicode text data; otherwise, false.</returns>
        bool ContainsText();
    }
}