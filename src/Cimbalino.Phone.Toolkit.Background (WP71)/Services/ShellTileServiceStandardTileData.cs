// ****************************************************************************
// <copyright file="ShellTileServiceStandardTileData.cs" company="Pedro Lamas">
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
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Data for a tile pinned to Start. Tiles have a ‘front’ and ‘back’ to them and this class holds all this data.
    /// </summary>
    public class ShellTileServiceStandardTileData : ShellTileServiceTileDataBase
    {
        #region Properties

        /// <summary>
        /// Gets or sets the background image of the back of the Tile. If this property is an empty Uri, the background image of the back of the tile will not change during an update.
        /// </summary>
        /// <value>The background image of the back of the Tile.</value>
        public Uri BackBackgroundImage { get; set; }

        /// <summary>
        /// Gets or sets the text to display on the back of the tile, above the title. If this property is an empty string, the content on the back of the tile will not change during an update.
        /// </summary>
        /// <value>The text to display on the back of the tile, above the title.</value>
        public string BackContent { get; set; }

        /// <summary>
        /// Gets or sets the background image of the front of the Tile. If this property is an empty Uri, the background image of the front of the tile will not change during an update.
        /// </summary>
        /// <value>The background image of the front of the Tile. If this property is an empty Uri, the background image of the front of the tile will not change during an update.</value>
        public Uri BackgroundImage { get; set; }

        /// <summary>
        /// Gets or sets the title to display at the bottom of the back of the Tile. If this property is an empty string, the title of the back of the tile will not change during an update.
        /// </summary>
        /// <value>The title to display at the bottom of the back of the Tile. If this property is an empty string, the title of the back of the tile will not change during an update.</value>
        public string BackTitle { get; set; }

        /// <summary>
        /// Gets or sets a value between 1 and 99 that will be displayed in the Count field of the Tile. A value of 0 means the Count will not be displayed. If this property is not set, the Count display will not change during an update.
        /// </summary>
        /// <value>A value between 1 and 99 that will be displayed in the Count field of the Tile.</value>
        public int? Count { get; set; }

        #endregion

        internal override ShellTileData ToShellTileData()
        {
            return new StandardTileData()
            {
                Title = Title,
                BackBackgroundImage = BackBackgroundImage,
                BackContent = BackContent,
                BackgroundImage = BackgroundImage,
                BackTitle = BackTitle,
                Count = Count
            };
        }
    }
}