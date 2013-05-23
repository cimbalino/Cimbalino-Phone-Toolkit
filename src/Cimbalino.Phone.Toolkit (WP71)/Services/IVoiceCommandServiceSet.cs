// ****************************************************************************
// <copyright file="IVoiceCommandServiceSet.cs" company="Pedro Lamas">
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

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an object capable of operations on a specific installed command set.
    /// </summary>
    public interface IVoiceCommandServiceSet
    {
        /// <summary>
        /// Gets the language of the command set.
        /// </summary>
        /// <value>The language of the command set.</value>
        string Language { get; }

        /// <summary>
        /// Gets the value of the CommandSet element's Name attribute.
        /// </summary>
        /// <value>The value of the CommandSet element's Name attribute.</value>
        string Name { get; }

        /// <summary>
        /// Populates a PhraseList element with an array of Item elements.
        /// </summary>
        /// <param name="phraseListName">The string that corresponds to the PhraseList element's label attribute.</param>
        /// <param name="phraseList">A string array of values that will be added to the PhraseList element as Item elements.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task UpdatePhraseListAsync(string phraseListName, IEnumerable<string> phraseList);
    }
}