// ****************************************************************************
// <copyright file="AddressChooserService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>24-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
#if WP8
using System.Threading.Tasks;
#endif
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IAddressChooserService"/>.
    /// </summary>
    public class AddressChooserService : IAddressChooserService
    {
        /// <summary>
        /// Shows the Contacts application, allowing the user to choose a contact for which the physical address is obtained.
        /// </summary>
        /// <param name="resultAction">The <see cref="Action{AddressResult}" /> to be called once the operation is finished.</param>
        public void Show(Action<AddressResult> resultAction)
        {
            new ChooserHandler<AddressResult>(new AddressChooserTask(), resultAction)
                .Show();
        }

#if WP8
        /// <summary>
        /// Shows the Contacts application, allowing the user to choose a contact for which the physical address is obtained.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<AddressResult> ShowAsync()
        {
            return new ChooserHandler<AddressResult>(new AddressChooserTask())
                .ShowAsync();
        }
#endif
    }
}