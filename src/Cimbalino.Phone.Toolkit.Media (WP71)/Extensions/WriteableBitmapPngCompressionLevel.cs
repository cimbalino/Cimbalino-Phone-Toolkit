// ****************************************************************************
// <copyright file="WriteableBitmapPngCompressionLevel.cs" company="Pedro Lamas">
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

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Describes the PNG compression level.
    /// </summary>
    public enum WriteableBitmapPngCompressionLevel
    {

        /// <summary>
        /// None means that the data will be simply stored, with no change at all. If you are producing ZIPs for use on Mac OSX, be aware that archives produced with CompressionLevel.None cannot be opened with the default zip reader. Use a different CompressionLevel.
        /// </summary>
        Level0 = 0,

        /// <summary>
        /// Same as <see cref="None"/>.
        /// </summary>
        None = 0,

        /// <summary>
        /// The fastest but least effective compression.
        /// </summary>
        BestSpeed = 1,

        /// <summary>
        /// Same as <see cref="BestSpeed"/>.
        /// </summary>
        Level1 = 1,

        /// <summary>
        /// A little slower, but better, than level 1.
        /// </summary>
        Level2 = 2,

        /// <summary>
        /// A little slower, but better, than level 2.
        /// </summary>
        Level3 = 3,

        /// <summary>
        /// A little slower, but better, than level 3.
        /// </summary>
        Level4 = 4,

        /// <summary>
        /// A little slower, but better, than level 4.
        /// </summary>
        Level5 = 5,

        /// <summary>
        /// The default compression level, with a good balance of speed and compression efficiency.
        /// </summary>
        Default = 6,

        /// <summary>
        /// Same as <see cref="Default"/>.
        /// </summary>
        Level6 = 6,

        /// <summary>
        /// Pretty good compression.
        /// </summary>
        Level7 = 7,

        /// <summary>
        /// Better compression than level 7.
        /// </summary>
        Level8 = 8,
        
        /// <summary>
        /// The "best" compression, where best means greatest reduction in size of the input data stream. This is also the slowest compression.
        /// </summary>
        BestCompression = 9,
        
        /// <summary>
        /// Same as <see cref="BestCompression"/>.
        /// </summary>
        Level9 = 9,
    }
}