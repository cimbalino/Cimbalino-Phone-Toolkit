// ****************************************************************************
// <copyright file="IVoiceCommandService.cs" company="Pedro Lamas">
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
using System.Threading.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of installing command sets from a Voice Command Definition (VCD) file, and getting installed command sets.
    /// </summary>
    public interface IVoiceCommandService
    {
        /// <summary>
        /// Installs the CommandSet elements in a Voice Command Definition (VCD) file.
        /// </summary>
        /// <param name="voiceCommandDefinitionUri">The absolute path to the Voice Command Definition (VCD) file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task InstallCommandSetsFromFileAsync(Uri voiceCommandDefinitionUri);

        /// <summary>
        /// Gets a dictionary that contains all installed command sets that have a Name attribute set in the Voice Command Definition (VCD) file.
        /// </summary>
        /// <value>A dictionary that contains all installed command sets that have a Name attribute set in the Voice Command Definition (VCD) file.</value>
        IDictionary<string, IVoiceCommandServiceSet> InstalledCommandSets { get; }
    }
}