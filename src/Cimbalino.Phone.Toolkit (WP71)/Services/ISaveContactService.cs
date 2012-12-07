// ****************************************************************************
// <copyright file="ISaveContactService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>07-12-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching the contacts application and enabling a user to save a contact.
    /// </summary>
    public interface ISaveContactService
    {
        /// <summary>
        /// Shows the contacts application and enables the user to save a contact, using the specified <see cref="SaveContactServiceParams"/> instance.
        /// </summary>
        /// <param name="saveContactServiceParams">The <see cref="SaveContactServiceParams"/> instance.</param>
        void Show(SaveContactServiceParams saveContactServiceParams);
    }
}