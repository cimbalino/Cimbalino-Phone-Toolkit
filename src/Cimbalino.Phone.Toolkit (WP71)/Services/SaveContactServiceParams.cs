// ****************************************************************************
// <copyright file="SaveContactServiceParams.cs" company="Pedro Lamas">
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
    /// The settings to be used when <see cref="M:SaveContactService.Show"/> is invoked.
    /// </summary>
    public class SaveContactServiceParams
    {
        /// <summary>
        /// Gets or sets the name of the company associated with the contact.
        /// </summary>
        /// <value>The name of the company.</value>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the given name of the contact.
        /// </summary>
        /// <value>The given name of the contact.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the city of the home address associated with the contact.
        /// </summary>
        /// <value>The city of the home address.</value>
        public string HomeAddressCity { get; set; }

        /// <summary>
        /// Gets or sets the country or region of the home address associated with the contact.
        /// </summary>
        /// <value>The country or region of the home address.</value>
        public string HomeAddressCountry { get; set; }

        /// <summary>
        /// Gets or sets the state of the home address associated with the contact.
        /// </summary>
        /// <value>The state of the home address.</value>
        public string HomeAddressState { get; set; }

        /// <summary>
        /// Gets or sets the street name and number of the home address associated with the contact.
        /// </summary>
        /// <value>The street name and number of the home address.</value>
        public string HomeAddressStreet { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the home address associated with the contact.
        /// </summary>
        /// <value>The postal code of the home address.</value>
        public string HomeAddressZipCode { get; set; }

        /// <summary>
        /// Gets or sets the home phone number associated with the contact.
        /// </summary>
        /// <value>The home phone number.</value>
        public string HomePhone { get; set; }

        /// <summary>
        /// Gets or sets the job title associated with the contact.
        /// </summary>
        /// <value>The job title of the contact.</value>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the surname of the contact.
        /// </summary>
        /// <value>The surname of the contact.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the contact.
        /// </summary>
        /// <value>The middle name of the contact.</value>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the mobile phone number associated with the contact.
        /// </summary>
        /// <value>The mobile phone number.</value>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Gets or sets the nickname of the contact.
        /// </summary>
        /// <value>The nickname of the contact.</value>
        public string Nickname { get; set; }

        /// <summary>
        /// Gets or sets a note associated with the contact.
        /// </summary>
        /// <value>The note associated with the contact.</value>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets an additional email address associated with the contact.
        /// </summary>
        /// <value>The additional email address.</value>
        public string OtherEmail { get; set; }

        /// <summary>
        /// Gets or sets the personal email address associated with the contact.
        /// </summary>
        /// <value>The personal email address.</value>
        public string PersonalEmail { get; set; }

        /// <summary>
        /// Gets or sets the suffix of the name of the contact.
        /// </summary>
        /// <value>The suffix of the name of the contact.</value>
        public string Suffix { get; set; }

        /// <summary>
        /// Gets or sets the title of the name of the contact.
        /// </summary>
        /// <value>The title of the name of the contact.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the website associated with the contact.
        /// </summary>
        /// <value>The website associated with the contact.</value>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the city of the work address associated with the contact.
        /// </summary>
        /// <value>The city of the work address.</value>
        public string WorkAddressCity { get; set; }

        /// <summary>
        /// Gets or sets the country or region of the work address associated with the contact.
        /// </summary>
        /// <value>The country or region of the work address.</value>
        public string WorkAddressCountry { get; set; }

        /// <summary>
        /// Gets or sets the state of the work address associated with the contact.
        /// </summary>
        /// <value>The state of the work address.</value>
        public string WorkAddressState { get; set; }

        /// <summary>
        /// Gets or sets the street name and number of the work address associated with the contact.
        /// </summary>
        /// <value>The street name and number of the work address.</value>
        public string WorkAddressStreet { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the work address associated with the contact.
        /// </summary>
        /// <value>The postal code of the work address.</value>
        public string WorkAddressZipCode { get; set; }

        /// <summary>
        /// Gets or sets the work email address associated with the contact.
        /// </summary>
        /// <value>The work email address.</value>
        public string WorkEmail { get; set; }

        /// <summary>
        /// Gets or sets the work phone number associated with the contact.
        /// </summary>
        /// <value>The work phone number.</value>
        public string WorkPhone { get; set; }
    }
}