// ****************************************************************************
// <copyright file="ShellTileWithCreateService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>21-05-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IShellTileService"/>.
    /// </summary>
    public class ShellTileWithCreateService : ShellTileService
    {
        /// <summary>
        /// Creates a new secondary tile.
        /// </summary>
        /// <param name="navigationUri"><see cref="Uri"/> for the tile being created. The <see cref="Uri"/> can contain custom launch parameters.</param>
        /// <param name="initialTileData">Text and image information for the tile being created.</param>
        /// <param name="supportsWideTile">true if the wide tile size is supported; otherwise, false.</param>
        public override void Create(Uri navigationUri, IShellTileServiceTileData initialTileData, bool supportsWideTile)
        {
            var shellTileServiceTileDataBase = initialTileData as ShellTileServiceTileDataBase;

            if (shellTileServiceTileDataBase == null)
            {
                throw new ArgumentException("A ShellTileServiceTileDataBase instance is expected.", "initialTileData");
            }
#if WP8
            ShellTile.Create(navigationUri, shellTileServiceTileDataBase.ToShellTileData(), supportsWideTile);
#else
            if (LiveTilesSupported)
            {
                var shellTileType = Type.GetType("Microsoft.Phone.Shell.ShellTile, Microsoft.Phone");
                var createmethod = shellTileType.GetMethod("Create", new[] { typeof(Uri), typeof(ShellTileData), typeof(bool) });

                createmethod.Invoke(null, new object[] { navigationUri, shellTileServiceTileDataBase.ToShellTileData(), supportsWideTile });
            }
            else
            {
                ShellTile.Create(navigationUri, shellTileServiceTileDataBase.ToShellTileData());
            }
#endif
        }
    }
}