using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    public class TileService : ITileService
    {
        /// <summary>
        /// Tiles the exists.
        /// </summary>
        /// <param name="uriString">The URI string.</param>
        /// <returns></returns>
        public bool TileExists(string uriString)
        {
            var tileExists = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(uriString));
            return tileExists != null;
        }

        /// <summary>
        /// Gets the tile.
        /// </summary>
        /// <param name="uriString">The URI string.</param>
        /// <returns></returns>
        public ShellTile GetTile(string uriString)
        {
            return ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(uriString));
        }

        /// <summary>
        /// Gets the primary tile.
        /// </summary>
        /// <value>
        /// The primary tile.
        /// </value>
        public ShellTile PrimaryTile
        {
            get { return ShellTile.ActiveTiles.First(); }
        }

#if !WP8
        private static readonly Version TargetedVersion = new Version(7, 10, 8858);

        /// <summary>
        /// Gets a value indicating whether [supports new tiles].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [supports new tiles]; otherwise, <c>false</c>.
        /// </value>
        public bool SupportsNewTiles
        {
            get { return Environment.OSVersion.Version >= TargetedVersion; }
        }

        /// <summary>
        /// Creates the new tile.
        /// </summary>
        /// <returns></returns>
        public StandardTileData CreateNewTile()
        {
            return new StandardTileData();
        }

        public void CreateTile(string uri, ShellTileData tileData)
        {
            ShellTile.Create(new Uri(uri, UriKind.Relative), tileData);
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
        #region Windows Phone 7.8 Tile Extension Methods
        /// <summary>
        /// Updates the flip tile through the use of reflection.
        /// </summary>
        /// <param name="shellTile">The tile data.</param>
        /// <param name="title">The title.</param>
        /// <param name="backTitle">The back title.</param>
        /// <param name="backContent">Content of the back.</param>
        /// <param name="wideBackContent">Content of the wide back.</param>
        /// <param name="count">The count.</param>
        /// <param name="tileId">The tile id.</param>
        /// <param name="smallBackgroundImage">The small background image.</param>
        /// <param name="backgroundImage">The background image.</param>
        /// <param name="backBackgroundImage">The back background image.</param>
        /// <param name="wideBackgroundImage">The wide background image.</param>
        /// <param name="wideBackBackgroundImage">The wide back background image.</param>
        public static void UpdateFlipTile(this ShellTile shellTile,
                                          string title = null,
                                          string backTitle = null,
                                          string backContent = null,
                                          string wideBackContent = null,
                                          int? count = null,
                                          Uri tileId = null,
                                          Uri smallBackgroundImage = null,
                                          Uri backgroundImage = null,
                                          Uri backBackgroundImage = null,
                                          Uri wideBackgroundImage = null,
                                          Uri wideBackBackgroundImage = null)
        {
            // Get the new FlipTileData type.
            var flipTileDataType = Type.GetType("Microsoft.Phone.Shell.FlipTileData, Microsoft.Phone");

            // Get the ShellTile type so we can call the new version of "Update" that takes the new Tile templates.
            var shellTileType = Type.GetType("Microsoft.Phone.Shell.ShellTile, Microsoft.Phone");

            // Get the constructor for the new FlipTileData class and assign it to our variable to hold the Tile properties.
            var updateTileData = flipTileDataType.GetConstructor(new Type[] {}).Invoke(null);

            // Set the properties. 
            SetProperty(updateTileData, "Title", title);
            SetProperty(updateTileData, "Count", count.HasValue ? count.Value : 0);
            SetProperty(updateTileData, "BackTitle", backTitle);
            SetProperty(updateTileData, "BackContent", backContent);
            SetProperty(updateTileData, "SmallBackgroundImage", smallBackgroundImage);
            SetProperty(updateTileData, "BackgroundImage", backgroundImage);
            SetProperty(updateTileData, "BackBackgroundImage", backBackgroundImage);
            SetProperty(updateTileData, "WideBackgroundImage", wideBackgroundImage);
            SetProperty(updateTileData, "WideBackBackgroundImage", wideBackBackgroundImage);
            SetProperty(updateTileData, "WideBackContent", wideBackContent);

            // Invoke the new version of ShellTile.Update.
            shellTileType.GetMethod("Update").Invoke(shellTile, new[] {updateTileData});
        }

        private static void SetProperty(object instance, string name, object value)
        {
            var setMethod = instance.GetType().GetProperty(name).GetSetMethod();
            setMethod.Invoke(instance, new [] { value });
        }
        #endregion

        #region StandardTileData Extension Methods
        public static StandardTileData AddTitle(this StandardTileData tileData, string title)
        {
            tileData.Title = title;
            return tileData;
        }

        public static StandardTileData AddCount(this StandardTileData tileData, int count)
        {
            tileData.Count = count;
            return tileData;
        }

        public static StandardTileData AddBackTitle(this StandardTileData tileData, string backTitle)
        {
            tileData.BackTitle = backTitle;
            return tileData;
        }

        public static StandardTileData AddBackgroundImage(this StandardTileData tileData, string backgroundImage)
        {
            tileData.BackgroundImage = new Uri(backgroundImage, UriKind.RelativeOrAbsolute);
            return tileData;
        }

        public static StandardTileData AddBackgroundImage(this StandardTileData tileData, Uri backgroundImage)
        {
            tileData.BackgroundImage = backgroundImage;
            return tileData;
        }

        public static StandardTileData AddBackContent(this StandardTileData tileData, string backContent)
        {
            tileData.BackContent = backContent;
            return tileData;
        }

        public static StandardTileData AddBackBackgroundImage(this StandardTileData tileData, string backBackgroundImage)
        {
            tileData.BackBackgroundImage = new Uri(backBackgroundImage, UriKind.RelativeOrAbsolute);
            return tileData;
        }

        public static StandardTileData AddBackBackgroundImage(this StandardTileData tileData, Uri backBackgroundImage)
        {
            tileData.BackBackgroundImage = backBackgroundImage;
            return tileData;
        }
        #endregion
#endif
    }
}
