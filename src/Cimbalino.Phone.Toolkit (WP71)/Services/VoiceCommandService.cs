// ****************************************************************************
// <copyright file="VoiceCommandService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>22-05-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
#if WP8
using System.Linq;
#endif
using System.Threading.Tasks;
#if WP8
using VoiceCommands = Windows.Phone.Speech.VoiceCommands;
#endif

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IVoiceCommandService"/>.
    /// </summary>
    public class VoiceCommandService : IVoiceCommandService
    {
        /// <summary>
        /// Installs the CommandSet elements in a Voice Command Definition (VCD) file.
        /// </summary>
        /// <param name="voiceCommandDefinitionUri">The absolute path to the Voice Command Definition (VCD) file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task InstallCommandSetsFromFileAsync(Uri voiceCommandDefinitionUri)
        {
#if WP8
            return VoiceCommands.VoiceCommandService.InstallCommandSetsFromFileAsync(voiceCommandDefinitionUri)
                .AsTask();
#else
            throw new NotSupportedException("This service is not supported in Windows Phone 7.x");
#endif
        }

        /// <summary>
        /// Gets a dictionary that contains all installed command sets that have a Name attribute set in the Voice Command Definition (VCD) file.
        /// </summary>
        /// <value>A dictionary that contains all installed command sets that have a Name attribute set in the Voice Command Definition (VCD) file.</value>
        public IDictionary<string, IVoiceCommandServiceSet> InstalledCommandSets
        {
            get
            {
#if WP8
                return VoiceCommands.VoiceCommandService.InstalledCommandSets
                    .ToDictionary(x => x.Key, x => (IVoiceCommandServiceSet)new VoiceCommandServiceSet(x.Value));
#else
                throw new NotSupportedException("This service is not supported in Windows Phone 7.x");
#endif
            }
        }
    }
}