// ****************************************************************************
// <copyright file="ShellTileService.cs" company="Pedro Lamas">
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
using System.Linq;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IShellTileService"/>.
    /// </summary>
    public class ShellTileService : IShellTileService
    {
#if !WP8
        internal static readonly bool LiveTilesSupportedStatic = Environment.OSVersion.Version >= new Version(7, 10, 8858);
#endif

        /// <summary>
        /// Gets a value indicating whether live tiles are supported.
        /// </summary>
        /// <value>true if live tiles are supported; otherwise, false.</value>
        public bool LiveTilesSupported
        {
            get
            {
#if !WP8
                return LiveTilesSupportedStatic;
#else
                return true;
#endif
            }
        }

        /// <summary>
        /// Gets the collection of an applications tiles pinned to Start.
        /// </summary>
        /// <value>The collection of an applications tiles pinned to Start.</value>
        public IEnumerable<IShellTileServiceTile> ActiveTiles
        {
            get
            {
                return ShellTile.ActiveTiles
                    .Select(x => (IShellTileServiceTile)new ShellTileServiceTile(x));
            }
        }

        /// <summary>
        /// Creates a new secondary tile.
        /// </summary>
        /// <param name="navigationUri"><see cref="Uri"/> for the tile being created. The <see cref="Uri"/> can contain custom launch parameters.</param>
        /// <param name="initialTileData">Text and image information for the tile being created.</param>
        /// <param name="supportsWideTile">true if the wide tile size is supported; otherwise, false.</param>
        public virtual void Create(Uri navigationUri, IShellTileServiceTileData initialTileData, bool supportsWideTile)
        {
            throw new NotSupportedException("To use this method, add Cimbalino.Phone.Toolkit assembly to the project and use the ShellTileWithCreateService instead. This method can't be called from a Background Agent.");
        }
    }
}