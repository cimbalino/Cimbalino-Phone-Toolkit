// ****************************************************************************
// <copyright file="ShellTileServiceIconicTileData.cs" company="Pedro Lamas">
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
using System.Windows.Media;
#if !WP8
using Cimbalino.Phone.Toolkit.Extensions;
#endif
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Describes an iconic Tile template.
    /// </summary>
    public class ShellTileServiceIconicTileData : ShellTileServiceTileDataBase
    {
        #region Properties

        /// <summary>
        /// Gets or sets the background color of the Tile. Setting this property overrides the default theme color that is set on the phone.
        /// </summary>
        /// <value>The background color of the Tile.</value>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets a value between 1 and 99 that will be displayed in the Count field of the Tile. A value of 0 means the Count will not be displayed. If this property is not set, the Count display will not change during an update.
        /// </summary>
        /// <value>A value between 1 and 99 that will be displayed in the Count field of the Tile.</value>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the icon image for the medium and large Tile sizes.
        /// </summary>
        /// <value>The icon image for the medium and large Tile sizes.</value>
        public Uri IconImage { get; set; }

        /// <summary>
        /// Gets or sets the icon image for the small Tile size.
        /// </summary>
        /// <value>The icon image for the small Tile size.</value>
        public Uri SmallIconImage { get; set; }

        /// <summary>
        /// Gets or sets the text that displays on the first row of the wide Tile size.
        /// </summary>
        /// <value>The text that displays on the first row of the wide Tile size.</value>
        public string WideContent1 { get; set; }

        /// <summary>
        /// Gets or sets the text that displays on the second row of the wide Tile size.
        /// </summary>
        /// <value>The text that displays on the second row of the wide Tile size.</value>
        public string WideContent2 { get; set; }

        /// <summary>
        /// Gets or sets the text that displays on the third row of the wide Tile size.
        /// </summary>
        /// <value>The text that displays on the third row of the wide Tile size.</value>
        public string WideContent3 { get; set; }

        #endregion

        internal override ShellTileData ToShellTileData()
        {
#if WP8
            return new IconicTileData()
            {
                Title = Title,
                BackgroundColor = BackgroundColor,
                Count = Count,
                IconImage = IconImage,
                SmallIconImage = SmallIconImage,
                WideContent1 = WideContent1,
                WideContent2 = WideContent2,
                WideContent3 = WideContent3
            };
#else
            if (!ShellTileService.LiveTilesSupportedStatic)
            {
                return new StandardTileData()
                {
                    Title = Title,
                    Count = Count,
                    BackTitle = WideContent1,
                    BackContent = WideContent2
                };
            }

            var iconicTileDataType = Type.GetType("Microsoft.Phone.Shell.IconicTileData, Microsoft.Phone");

            var iconicTileData = (ShellTileData)iconicTileDataType.GetConstructor(new Type[] { }).Invoke(null);

            iconicTileData.Title = Title;
            iconicTileData.SetPropertyValue("BackgroundColor", BackgroundColor);
            iconicTileData.SetPropertyValue("Count", Count);
            iconicTileData.SetPropertyValue("IconImage", IconImage);
            iconicTileData.SetPropertyValue("SmallIconImage", SmallIconImage);
            iconicTileData.SetPropertyValue("WideContent1", WideContent1);
            iconicTileData.SetPropertyValue("WideContent2", WideContent2);
            iconicTileData.SetPropertyValue("WideContent3", WideContent3);

            return iconicTileData;
#endif
        }
    }
}