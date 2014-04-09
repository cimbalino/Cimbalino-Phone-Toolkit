// ****************************************************************************
// <copyright file="SaveRingtoneService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>09-04-2014</date>
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
    /// Represents an implementation of the <see cref="ISaveRingtoneService"/>.
    /// </summary>
    public class SaveRingtoneService : ISaveRingtoneService
    {
        /// <summary>
        /// Shows the ringtones application.
        /// </summary>
        /// <param name="resultAction">The <see cref="Action{TaskEventArgs}" /> to be called once the operation is finished.</param>
        public void Show(Action<TaskEventArgs> resultAction)
        {
            new ChooserHandler<TaskEventArgs>(new SaveRingtoneTask(), resultAction)
                .Show();
        }

        /// <summary>
        /// Shows the ringtones application.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<TaskEventArgs> ShowAsync()
        {
            return new ChooserHandler<TaskEventArgs>(new SaveRingtoneTask())
                .ShowAsync();
        }
    }
}