using System;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    public interface ITileService
    {
        bool TileExists(string uriString);
        ShellTile GetTile(string uriString);
        ShellTile PrimaryTile { get; }

#if WP8
        /// <summary>
        /// Creates the new flip tile.
        /// </summary>
        /// <returns></returns>
        FlipTileData CreateNewFlipTile();

        /// <summary>
        /// Creates the new flip tile.
        /// </summary>
        /// <param name="xmlContent">Content of the XML.</param>
        /// <returns></returns>
        FlipTileData CreateNewFlipTile(string xmlContent);

        /// <summary>
        /// Creates the new cycle tile.
        /// </summary>
        /// <returns></returns>
        CycleTileData CreateNewCycleTile();

        /// <summary>
        /// Creates the new cycle tile.
        /// </summary>
        /// <param name="xmlContent">Content of the XML.</param>
        /// <returns></returns>
        CycleTileData CreateNewCycleTile(string xmlContent);

        /// <summary>
        /// Creates the new iconic tile.
        /// </summary>
        /// <returns></returns>
        IconicTileData CreateNewIconicTile();

        /// <summary>
        /// Creates the new iconic tile.
        /// </summary>
        /// <param name="xmlContent">Content of the XML.</param>
        /// <returns></returns>
        IconicTileData CreateNewIconicTile(string xmlContent);

        /// <summary>
        /// Creates the tile.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="tileData">The tile data.</param>
        /// <param name="supportsWideTile">if set to <c>true</c> [supports wide tile].</param>
        void CreateTile(string uri, ShellTileData tileData, bool supportsWideTile);

        /// <summary>
        /// Creates the tile.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="tileData">The tile data.</param>
        /// <param name="supportsWideTile">if set to <c>true</c> [supports wide tile].</param>
        void CreateTile(Uri uri, ShellTileData tileData, bool supportsWideTile);
#else
        /// <summary>
        /// Creates the new tile.
        /// </summary>
        /// <returns></returns>
        StandardTileData CreateNewTile();

        /// <summary>
        /// Gets a value indicating whether [supports new tiles].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [supports new tiles]; otherwise, <c>false</c>.
        /// </value>
        bool SupportsNewTiles { get; }

        void CreateTile(string uri, ShellTileData tileData);
#endif
    }
}