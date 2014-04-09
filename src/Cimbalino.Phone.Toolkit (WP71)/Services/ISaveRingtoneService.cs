// ****************************************************************************
// <copyright file="ISaveRingtoneService.cs" company="Pedro Lamas">
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
    /// Represents a service capable of launching the ringtones application. Use this to allow users to save a ringtone from your application to the system ringtones list.
    /// </summary>
    public interface ISaveRingtoneService
    {
        /// <summary>
        /// Shows the ringtones application.
        /// </summary>
        /// <param name="resultAction">The <see cref="Action{TaskEventArgs}" /> to be called once the operation is finished.</param>
        void Show(Action<TaskEventArgs> resultAction);

        /// <summary>
        /// Shows the ringtones application.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<TaskEventArgs> ShowAsync();
    }
}