// ****************************************************************************
// <copyright file="SaveEmailAddressService.cs" company="Pedro Lamas">
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
    /// Represents an implementation of the <see cref="ISaveEmailAddressService"/>.
    /// </summary>
    public class SaveEmailAddressService : ISaveEmailAddressService
    {
        /// <summary>
        /// Shows the contacts application, using the specified email address.
        /// </summary>
        /// <param name="emailAddress">The email address that can be saved to a contact.</param>
        public void Show(string emailAddress)
        {
            new SaveEmailAddressTask()
            {
                Email = emailAddress
            }.Show();
        }
    }
}