// ****************************************************************************
// <copyright file="ShellTileServiceCycleTileData.cs" company="Pedro Lamas">
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
using System.Collections.Generic;
using System.Linq;
using Cimbalino.Phone.Toolkit.Extensions;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    public class ShellTileServiceCycleTileData : ShellTileServiceTileDataBase
    {
        #region Properties

        public int? Count { set; get; }

        public IEnumerable<Uri> CycleImages { set; get; }

        public Uri SmallBackgroundImage { set; get; }

        #endregion

        internal override ShellTileData ToShellTileData()
        {
#if WP8
            return new CycleTileData()
            {
                Title = Title,
                Count = Count,
                CycleImages = CycleImages,
                SmallBackgroundImage = SmallBackgroundImage
            };
#else
            if (!ShellTileService.LiveTilesSupportedStatic)
            {
                return new StandardTileData()
                {
                    Title = Title,
                    Count = Count,
                    BackgroundImage = CycleImages.FirstOrDefault()
                };
            }

            var flipTileDataType = Type.GetType("Microsoft.Phone.Shell.CycleTileData, Microsoft.Phone");

            var flipTileData = (ShellTileData)flipTileDataType.GetConstructor(new Type[] { }).Invoke(null);

            flipTileData.Title = Title;
            flipTileData.SetPropertyValue("Count", Count);
            flipTileData.SetPropertyValue("SmallBackgroundImage", SmallBackgroundImage);
            flipTileData.SetPropertyValue("CycleImages", CycleImages);

            return flipTileData;
#endif
        }
    }
}