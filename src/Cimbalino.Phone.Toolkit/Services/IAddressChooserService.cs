// ****************************************************************************
// <copyright file="IAddressChooserService.cs" company="Pedro Lamas">
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
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching the Contacts application.
    /// </summary>
    public interface IAddressChooserService
    {
        /// <summary>
        /// Shows the Contacts application, allowing the user to choose a contact for which the physical address is obtained.
        /// </summary>
        /// <param name="resultAction">The <see cref="Action{AddressResult}"/> to be called once the operation is finished.</param>
        void Show(Action<AddressResult> resultAction);
    }
}