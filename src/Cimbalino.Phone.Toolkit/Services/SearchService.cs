// ****************************************************************************
// <copyright file="SearchService.cs" company="Pedro Lamas">
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

using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ISearchService"/>.
    /// </summary>
    public class SearchService : ISearchService
    {
        /// <summary>
        /// Shows the Web Search application, using the specified search query.
        /// </summary>
        /// <param name="searchQuery">The search query that the Web Search application will use when it is launched.</param>
        public void Show(string searchQuery)
        {
            new SearchTask()
            {
                SearchQuery = searchQuery
            }.Show();
        }
    }
}