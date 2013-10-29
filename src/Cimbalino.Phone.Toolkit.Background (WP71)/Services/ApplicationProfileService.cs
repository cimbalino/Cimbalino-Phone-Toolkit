// ****************************************************************************
// <copyright file="ApplicationProfileService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-03-2013</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

#if WP8
using Windows.Phone.ApplicationModel;
#endif

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IApplicationProfileService"/>.
    /// </summary>
    public class ApplicationProfileService : IApplicationProfileService
    {
        /// <summary>
        /// Gets a value that indicates the mode that an app is running in.
        /// </summary>
        /// <value>A value that indicates the mode that an app is running in.</value>
        public ApplicationProfileServiceMode Mode
        {
            get
            {
#if WP8
                switch (ApplicationProfile.Modes)
                {
                    case ApplicationProfileModes.Default:
                        return ApplicationProfileServiceMode.Default;
                    
                    case ApplicationProfileModes.Alternate:
                        return ApplicationProfileServiceMode.KidsCorner;
                    
                    default:
                        return ApplicationProfileServiceMode.Unknown;
                }
#else
                return ApplicationProfileServiceMode.Default;
#endif
            }
        }
    }
}