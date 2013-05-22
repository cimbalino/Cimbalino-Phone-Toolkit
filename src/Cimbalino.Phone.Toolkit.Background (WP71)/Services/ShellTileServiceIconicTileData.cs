// ****************************************************************************
// <copyright file="ShellTileServiceIconicTileData.cs" company="Pedro Lamas">
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
using System.Windows.Media;
using Cimbalino.Phone.Toolkit.Extensions;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    public class ShellTileServiceIconicTileData : ShellTileServiceTileDataBase
    {
        #region Properties

        public Color BackgroundColor { get; set; }

        public int Count { get; set; }

        public Uri IconImage { get; set; }

        public Uri SmallIconImage { set; get; }

        public string WideContent1 { set; get; }

        public string WideContent2 { set; get; }

        public string WideContent3 { set; get; }

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