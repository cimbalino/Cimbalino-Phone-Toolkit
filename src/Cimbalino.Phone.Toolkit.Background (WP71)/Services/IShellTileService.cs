// ****************************************************************************
// <copyright file="IShellTileService.cs" company="Pedro Lamas">
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
using System.Collections.Generic;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of managing the Application Tile and secondary Tiles for an application. 
    /// </summary>
    public interface IShellTileService
    {
        /// <summary>
        /// Gets a value indicating whether live tiles are supported.
        /// </summary>
        /// <value>true if live tiles are supported; otherwise, false.</value>
        bool LiveTilesSupported { get; }

        /// <summary>
        /// Gets the collection of an applications tiles pinned to Start.
        /// </summary>
        /// <value>The collection of an applications tiles pinned to Start.</value>
        IEnumerable<IShellTileServiceTile> ActiveTiles { get; }

        /// <summary>
        /// Creates a new secondary tile.
        /// </summary>
        /// <param name="navigationUri"><see cref="Uri"/> for the tile being created. The <see cref="Uri"/> can contain custom launch parameters.</param>
        /// <param name="initialTileData">Text and image information for the tile being created.</param>
        /// <param name="supportsWideTile">true if the wide tile size is supported; otherwise, false.</param>
        void Create(Uri navigationUri, IShellTileServiceTileData initialTileData, bool supportsWideTile);
    }
}