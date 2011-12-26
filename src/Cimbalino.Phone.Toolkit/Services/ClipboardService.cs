// ****************************************************************************
// <copyright file="ClipboardService.cs" company="Pedro Lamas">
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

using System.Windows;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IClipboardService"/>.
    /// </summary>
    public class ClipboardService : IClipboardService
    {
        /// <summary>
        /// Sets Unicode text data to store on the clipboard.
        /// </summary>
        /// <param name="text">A string that contains the Unicode text data to store on the clipboard.</param>
        public void SetText(string text)
        {
            Clipboard.SetText(text);
        }

        /// <summary>
        /// Queries the clipboard for the presence of data in the UnicodeText format.
        /// </summary>
        /// <returns>
        /// true if the system clipboard contains Unicode text data; otherwise, false.
        /// </returns>
        public bool ContainsText()
        {
            return Clipboard.ContainsText();
        }
    }
}