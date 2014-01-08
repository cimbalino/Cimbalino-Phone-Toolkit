// ****************************************************************************
// <copyright file="IShellTileServiceTile.cs" company="Pedro Lamas">
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

using System;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an object capable of managing a Tile for an application.
    /// </summary>
    public interface IShellTileServiceTile
    {
        /// <summary>
        /// Gets the <see cref="Uri"/> and launch parameter this is navigated to when a secondary tile is tapped.
        /// </summary>
        /// <value>The <see cref="Uri"/> and launch parameter this is navigated to when a secondary tile is tapped.</value>
        Uri NavigationUri { get; }

        /// <summary>
        /// Updates an Application Tile or secondary Tile.
        /// </summary>
        /// <param name="data">New text and image data for the tile.</param>
        void Update(IShellTileServiceTileData data);

        /// <summary>
        /// Updates an Application Tile or secondary Tile.
        /// </summary>
        /// <param name="xmlData">The XML document that contains the tile data template information.</param>
        void Update(string xmlData);

        /// <summary>
        /// Unpins and deletes a secondary tile.
        /// </summary>
        void Delete();
    }
}