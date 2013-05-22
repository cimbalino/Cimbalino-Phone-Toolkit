// ****************************************************************************
// <copyright file="ShellTileServiceStandardTileData.cs" company="Pedro Lamas">
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
    public class ShellTileServiceStandardTileData : ShellTileServiceTileDataBase
    {
        #region Properties

        public Uri BackBackgroundImage { get; set; }

        public string BackContent { get; set; }

        public Uri BackgroundImage { set; get; }

        public string BackTitle { set; get; }

        public int? Count { set; get; }

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