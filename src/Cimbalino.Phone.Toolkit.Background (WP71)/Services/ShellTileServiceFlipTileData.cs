// ****************************************************************************
// <copyright file="ShellTileServiceFlipTileData.cs" company="Pedro Lamas">
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
using Cimbalino.Phone.Toolkit.Extensions;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    public class ShellTileServiceFlipTileData : ShellTileServiceStandardTileData
    {
        #region Properties

        public Uri SmallBackgroundImage { set; get; }

        public Uri WideBackgroundImage { set; get; }

        public Uri WideBackBackgroundImage { set; get; }

        public string WideBackContent { set; get; }

        #endregion

        internal override ShellTileData ToShellTileData()
        {
#if WP8
            return new FlipTileData()
            {
                Title = Title,
                BackBackgroundImage = BackBackgroundImage,
                BackContent = BackContent,
                BackTitle = BackTitle,
                BackgroundImage = BackgroundImage,
                Count = Count,
                SmallBackgroundImage = SmallBackgroundImage,
                WideBackBackgroundImage = WideBackBackgroundImage,
                WideBackContent = WideBackContent,
                WideBackgroundImage = WideBackgroundImage
            };
#else
            if (!ShellTileService.LiveTilesSupportedStatic)
            {
                return base.ToShellTileData();
            }

            var flipTileDataType = Type.GetType("Microsoft.Phone.Shell.FlipTileData, Microsoft.Phone");

            var flipTileData = (StandardTileData)flipTileDataType.GetConstructor(new Type[] { }).Invoke(null);

            flipTileData.Title = Title;
            flipTileData.BackBackgroundImage = BackBackgroundImage;
            flipTileData.BackContent = BackContent;
            flipTileData.BackgroundImage = BackgroundImage;
            flipTileData.BackTitle = BackTitle;
            flipTileData.Count = Count;
            flipTileData.SetPropertyValue("SmallBackgroundImage", SmallBackgroundImage);
            flipTileData.SetPropertyValue("WideBackgroundImage", WideBackgroundImage);
            flipTileData.SetPropertyValue("WideBackBackgroundImage", WideBackBackgroundImage);
            flipTileData.SetPropertyValue("WideBackContent", WideBackContent);

            return flipTileData;
#endif
        }
    }
}