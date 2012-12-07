// ****************************************************************************
// <copyright file="SaveContactService.cs" company="Pedro Lamas">
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

using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ISaveContactService"/>.
    /// </summary>
    public class SaveContactService : ISaveContactService
    {
        /// <summary>
        /// Shows the contacts application and enables the user to save a contact, using the specified <see cref="SaveContactServiceParams"/> instance.
        /// </summary>
        /// <param name="saveContactServiceParams">The <see cref="SaveContactServiceParams"/> instance.</param>
        public void Show(SaveContactServiceParams saveContactServiceParams)
        {
            var saveContactTask = new SaveContactTask()
            {
                Title = saveContactServiceParams.Title,
                Suffix = saveContactServiceParams.Suffix,
                FirstName = saveContactServiceParams.FirstName,
                MiddleName = saveContactServiceParams.MiddleName,
                LastName = saveContactServiceParams.LastName,
                HomeAddressCity = saveContactServiceParams.HomeAddressCity,
                HomeAddressCountry = saveContactServiceParams.HomeAddressCountry,
                HomeAddressState = saveContactServiceParams.HomeAddressState,
                HomeAddressStreet = saveContactServiceParams.HomeAddressState,
                HomeAddressZipCode = saveContactServiceParams.HomeAddressZipCode,
                HomePhone = saveContactServiceParams.HomePhone,
                WorkAddressCity = saveContactServiceParams.WorkAddressCity,
                WorkAddressCountry = saveContactServiceParams.WorkAddressCountry,
                WorkAddressState = saveContactServiceParams.WorkAddressState,
                WorkAddressStreet = saveContactServiceParams.WorkAddressStreet,
                WorkAddressZipCode = saveContactServiceParams.WorkAddressZipCode,
                WorkEmail = saveContactServiceParams.WorkEmail,
                WorkPhone = saveContactServiceParams.WorkPhone,
                Company = saveContactServiceParams.Company,
                JobTitle = saveContactServiceParams.JobTitle,
                MobilePhone = saveContactServiceParams.MobilePhone,
                Nickname = saveContactServiceParams.Nickname,
                Notes = saveContactServiceParams.Notes,
                PersonalEmail = saveContactServiceParams.PersonalEmail,
                OtherEmail = saveContactServiceParams.OtherEmail,
                Website = saveContactServiceParams.Website
            };

            saveContactTask.Show();
        }
    }
}