using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    public class TileService
    {
        public bool TileExists(string uriString)
        {
            var tileExists = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(uriString));
            return tileExists != null;
        }

        public ShellTile GetTile(string uriString)
        {
            return ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(uriString));
        }

        public ShellTile PrimaryTile
        {
            get { return ShellTile.ActiveTiles.First(); }
        }

#if !WP8
        public StandardTileData CreateNewTile()
        {
            return new StandardTileData();
        }
#else
        /// <summary>
        /// Creates the new flip tile.
        /// </summary>
        /// <returns></returns>
        public FlipTileData CreateNewFlipTile()
        {
            return new FlipTileData();
        }

        /// <summary>
        /// Creates the new flip tile.
        /// </summary>
        /// <param name="xmlContent">Content of the XML.</param>
        /// <returns></returns>
        public FlipTileData CreateNewFlipTile(string xmlContent)
        {
            return new FlipTileData(xmlContent);
        }

        /// <summary>
        /// Creates the new cycle tile.
        /// </summary>
        /// <returns></returns>
        public CycleTileData CreateNewCycleTile()
        {
            return new CycleTileData();
        }

        /// <summary>
        /// Creates the new cycle tile.
        /// </summary>
        /// <param name="xmlContent">Content of the XML.</param>
        /// <returns></returns>
        public CycleTileData CreateNewCycleTile(string xmlContent)
        {
            return new CycleTileData(xmlContent);
        }

        /// <summary>
        /// Creates the new iconic tile.
        /// </summary>
        /// <returns></returns>
        public IconicTileData CreateNewIconicTile()
        {
            return new IconicTileData();
        }

        /// <summary>
        /// Creates the new iconic tile.
        /// </summary>
        /// <param name="xmlContent">Content of the XML.</param>
        /// <returns></returns>
        public IconicTileData CreateNewIconicTile(string xmlContent)
        {
            return new IconicTileData(xmlContent);
        }

        /// <summary>
        /// Creates the tile.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="tileData">The tile data.</param>
        /// <param name="supportsWideTile">if set to <c>true</c> [supports wide tile].</param>
        public void CreateTile(string uri, ShellTileData tileData, bool supportsWideTile)
        {
            CreateTile(new Uri(uri, UriKind.Relative), tileData, supportsWideTile);
        }

        /// <summary>
        /// Creates the tile.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="tileData">The tile data.</param>
        /// <param name="supportsWideTile">if set to <c>true</c> [supports wide tile].</param>
        public void CreateTile(Uri uri, ShellTileData tileData, bool supportsWideTile)
        {
            ShellTile.Create(uri, tileData, supportsWideTile);
        }

        
#endif
    }

    public static class TileServiceExtensions
    {
#if WP8
        #region FlipTileData ExtensionMethods
        public static FlipTileData AddTitle(this FlipTileData tile, string title)
        {
            tile.Title = title;
            return tile;
        }

        public static FlipTileData AddCount(this FlipTileData tile, int count)
        {
            tile.Count = count;
            return tile;
        }

        public static FlipTileData AddBackTitle(this FlipTileData tile, string backTitle)
        {
            tile.BackTitle = backTitle;
            return tile;
        }

        public static FlipTileData AddBackContent(this FlipTileData tile, string backContent)
        {
            tile.BackContent = backContent;
            return tile;
        }

        public static FlipTileData AddWideBackContent(this FlipTileData tile, string wideBackContent)
        {
            tile.WideBackContent = wideBackContent;
            return tile;
        }

        public static FlipTileData AddSmallBackgroundImage(this FlipTileData tile, string smallBackgroundImage)
        {
            tile.SmallBackgroundImage = new Uri(smallBackgroundImage, UriKind.RelativeOrAbsolute);
            return tile;
        }

        public static FlipTileData AddSmallBackgroundImage(this FlipTileData tile, Uri smallBackgroundImage)
        {
            tile.SmallBackgroundImage = smallBackgroundImage;
            return tile;
        }

        public static FlipTileData AddBackgroundImage(this FlipTileData tile, string backgroundImage)
        {
            tile.BackgroundImage = new Uri(backgroundImage, UriKind.RelativeOrAbsolute);
            return tile;
        }

        public static FlipTileData AddBackgroundImage(this FlipTileData tile, Uri backgroundImage)
        {
            tile.BackgroundImage = backgroundImage;
            return tile;
        }

        public static FlipTileData AddWideBackgroundImage(this FlipTileData tile, string wideBackgroundImage)
        {
            tile.WideBackgroundImage = new Uri(wideBackgroundImage, UriKind.RelativeOrAbsolute);
            return tile;
        }

        public static FlipTileData AddWideBackgroundImage(this FlipTileData tile, Uri wideBackgroundImage)
        {
            tile.WideBackgroundImage = wideBackgroundImage;
            return tile;
        }

        public static FlipTileData AddBackBackgroundImage(this FlipTileData tile, string backBackgroundImage)
        {
            tile.BackBackgroundImage = new Uri(backBackgroundImage, UriKind.RelativeOrAbsolute);
            return tile;
        }

        public static FlipTileData AddBackBackgroundImage(this FlipTileData tile, Uri backBackgroundImage)
        {
            tile.BackBackgroundImage = backBackgroundImage;
            return tile;
        }

        public static FlipTileData AddWideBackBackgroundImage(this FlipTileData tile, string wideBackBackgroundImage)
        {
            tile.WideBackBackgroundImage = new Uri(wideBackBackgroundImage, UriKind.RelativeOrAbsolute);
            return tile;
        }

        public static FlipTileData AddWideBackBackgroundImage(this FlipTileData tile, Uri wideBackBackgroundImage)
        {
            tile.WideBackBackgroundImage = wideBackBackgroundImage;
            return tile;
        }
        #endregion

        #region CycleTileData ExtensionMethods
        public static CycleTileData AddTitle(this CycleTileData tile, string title)
        {
            tile.Title = title;
            return tile;
        }

        public static CycleTileData AddCount(this CycleTileData tile, int count)
        {
            tile.Count = count;
            return tile;
        }

        public static CycleTileData AddSmallBackgroundImage(this CycleTileData tile, string smallBackgroundImage)
        {
            tile.SmallBackgroundImage = new Uri(smallBackgroundImage, UriKind.RelativeOrAbsolute);
            return tile;
        }

        public static CycleTileData AddSmallBackgroundImage(this CycleTileData tile, Uri smallBackgroundImage)
        {
            tile.SmallBackgroundImage = smallBackgroundImage;
            return tile;
        }

        public static CycleTileData AddCycleImages(this CycleTileData tile, List<Uri> cycleImages)
        {
            tile.CycleImages = cycleImages;
            return tile;
        }

        public static CycleTileData AddCycleImages(this CycleTileData tile, List<string> cycleImages)
        {
            var cycleImageUris = new List<Uri>();
            
            cycleImages.ForEach(image => cycleImageUris.Add(new Uri(image, UriKind.RelativeOrAbsolute)));

            return tile.AddCycleImages(cycleImageUris);
        }
        #endregion

        #region IconicTileData ExtensionMethods
        public static IconicTileData AddTitle(this IconicTileData tile, string title)
        {
            tile.Title = title;
            return tile;
        }

        public static IconicTileData AddCount(this IconicTileData tile, int count)
        {
            tile.Count = count;
            return tile;
        }

        public static IconicTileData AddIconImage(this IconicTileData tile, string iconImage)
        {
            tile.IconImage = new Uri(iconImage, UriKind.RelativeOrAbsolute);
            return tile;
        }

        public static IconicTileData AddIconImage(this IconicTileData tile, Uri iconImage)
        {
            tile.IconImage = iconImage;
            return tile;
        }

        public static IconicTileData AddSmallIconImage(this IconicTileData tile, string smallIconImage)
        {
            tile.SmallIconImage = new Uri(smallIconImage, UriKind.RelativeOrAbsolute);
            return tile;
        }

        public static IconicTileData AddSmallIconImage(this IconicTileData tile, Uri smallIconImage)
        {
            tile.SmallIconImage = smallIconImage;
            return tile;
        }
        
        public static IconicTileData AddWideContent1(this IconicTileData tile, string wideContent1)
        {
            tile.WideContent1 = wideContent1;
            return tile;
        }

        public static IconicTileData AddWideContent2(this IconicTileData tile, string wideContent2)
        {
            tile.WideContent2 = wideContent2;
            return tile;
        }

        public static IconicTileData AddWideContent3(this IconicTileData tile, string wideContent3)
        {
            tile.WideContent3 = wideContent3;
            return tile;
        }

        public static IconicTileData AddBackgroundColor(this IconicTileData tile, Color backgroundColor)
        {
            tile.BackgroundColor = backgroundColor;
            return tile;
        }
        #endregion

#else

#endif
    }
}
