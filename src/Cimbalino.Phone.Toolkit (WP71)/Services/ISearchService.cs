// ****************************************************************************
// <copyright file="ISearchService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>25-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching the Web Search application.
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Shows the Web Search application, using the specified search query.
        /// </summary>
        /// <param name="searchQuery">The search query that the Web Search application will use when it is launched.</param>
        void Show(string searchQuery);
    }
}