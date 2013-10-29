// ****************************************************************************
// <copyright file="WriteableBitmapSavePngParameters.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>28-10-2013</date>
// <project>Cimbalino.Phone.Toolkit.Media</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Diagnostics.CodeAnalysis;
using Cimbalino.Phone.Toolkit.Compression;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// The <see cref="WriteableBitmapExtensions.SavePng(System.Windows.Media.Imaging.WriteableBitmap,System.IO.Stream,WriteableBitmapSavePngParameters)"/> parameters.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class WriteableBitmapSavePngParameters
    {
        #region Properties

        /// <summary>
        /// Gets or sets the picture compression level.
        /// </summary>
        /// <value>The picture compression level.</value>
        public CompressionLevel CompressionLevel { get; set; }

        /// <summary>
        /// Gets or sets the picture horizontal resolution.
        /// </summary>
        /// <value>The picture horizontal resolution.</value>
        public int HorizontalResolution { get; set; }

        /// <summary>
        /// Gets or sets the picture vertical resolution.
        /// </summary>
        /// <value>The picture vertical resolution.</value>
        public int VerticalResolution { get; set; }

        /// <summary>
        /// Gets or sets the picture gamma.
        /// </summary>
        /// <value>The picture gamma.</value>
        public double Gamma { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to save the picture resolution information.
        /// </summary>
        /// <value>
        /// true to save the picture resolution information; otherwise, false.
        /// </value>
        public bool SaveResolution { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to save the picture gamma information.
        /// </summary>
        /// <value>
        /// true to save the picture gamma information; otherwise, false.
        /// </value>
        public bool SaveGamma { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="WriteableBitmapSavePngParameters"/> class.
        /// </summary>
        public WriteableBitmapSavePngParameters()
        {
            CompressionLevel = CompressionLevel.Default;
            HorizontalResolution = VerticalResolution = 75;
            Gamma = 2.2;
            SaveResolution = true;
            SaveGamma = false;
        }
    }
}