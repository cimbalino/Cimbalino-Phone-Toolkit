// ****************************************************************************
// <copyright file="SavePhoneNumberService.cs" company="Pedro Lamas">
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
    /// Represents an implementation of the <see cref="ISavePhoneNumberService"/>.
    /// </summary>
    public class SavePhoneNumberService : ISavePhoneNumberService
    {
        /// <summary>
        /// Shows the contacts application, using the specified phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number that can be saved to a contact.</param>
        public void Show(string phoneNumber)
        {
            new SavePhoneNumberTask()
            {
                PhoneNumber = phoneNumber
            }.Show();
        }
    }
}