// ****************************************************************************
// <copyright file="IEmailAddressChooserService.cs" company="Pedro Lamas">
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

using System;
using System.Threading.Tasks;
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching the Contacts application. Use this to obtain the email address of a contact selected by the user.
    /// </summary>
    public interface IEmailAddressChooserService
    {
        /// <summary>
        /// Shows the email address chooser application.
        /// </summary>
        /// <param name="resultAction">The <see cref="Action{EmailResult}" /> to be called once the operation is finished.</param>
        void Show(Action<EmailResult> resultAction);

        /// <summary>
        /// Shows the email address chooser application.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<EmailResult> ShowAsync();
    }
}