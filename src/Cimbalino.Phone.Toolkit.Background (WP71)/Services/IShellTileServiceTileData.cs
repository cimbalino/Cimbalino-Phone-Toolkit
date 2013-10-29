// ****************************************************************************
// <copyright file="IShellTileServiceTileData.cs" company="Pedro Lamas">
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

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an object capable of handling tile data.
    /// </summary>
    public interface IShellTileServiceTileData
    {
        /// <summary>
        /// Gets or sets the text to display in the tile.
        /// </summary>
        /// <value>The text to display in the tile.</value>
        string Title { get; set; }
    }
}