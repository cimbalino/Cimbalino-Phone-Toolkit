// ****************************************************************************
// <copyright file="ShellTileServiceTileDataBase.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>21-05-2013</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IShellTileServiceTileData"/>.
    /// </summary>
    public abstract class ShellTileServiceTileDataBase : IShellTileServiceTileData
    {
        #region Properties

        /// <summary>
        /// Gets or sets the text to display in the tile.
        /// </summary>
        /// <value>The text to display in the tile.</value>
        public string Title { get; set; }

        #endregion

        internal abstract ShellTileData ToShellTileData();
    }
}