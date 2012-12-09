// ****************************************************************************
// <copyright file="EmailAddressChooserService.cs" company="Pedro Lamas">
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
#if WP8
using System.Threading.Tasks;
#endif
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IEmailAddressChooserService"/>.
    /// </summary>
    public class EmailAddressChooserService : IEmailAddressChooserService
    {
        /// <summary>
        /// Shows the email address chooser application.
        /// </summary>
        /// <param name="resultAction">The <see cref="Action{EmailResult}" /> to be called once the operation is finished.</param>
        public void Show(Action<EmailResult> resultAction)
        {
            new ChooserHandler<EmailResult>(new EmailAddressChooserTask(), resultAction)
                .Show();
        }

#if WP8
        /// <summary>
        /// Shows the email address chooser application.
        /// </summary>
        /// <returns>The <see cref="Task{EmailResult}"/> object representing the asynchronous operation.</returns>
        public Task<EmailResult> ShowAsync()
        {
            return new ChooserHandler<EmailResult>(new EmailAddressChooserTask())
                .ShowAsync();
        }
#endif
    }
}