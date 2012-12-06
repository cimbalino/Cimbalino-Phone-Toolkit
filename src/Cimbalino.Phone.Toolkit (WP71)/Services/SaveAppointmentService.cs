// ****************************************************************************
// <copyright file="SaveAppointmentService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>05-12-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

#if WP8
using Microsoft.Phone.Tasks;
#else
using System;
#endif

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ISaveAppointmentService"/>.
    /// </summary>
    public class SaveAppointmentService : ISaveAppointmentService
    {
        /// <summary>
        /// Shows the calendar application with a new appointment displayed, using the <see cref="SaveAppointmentServiceParams"/> instance.
        /// </summary>
        /// <param name="saveAppointmentServiceParams">The <see cref="SaveAppointmentServiceParams"/> instance.</param>
        public void Show(SaveAppointmentServiceParams saveAppointmentServiceParams)
        {
#if WP8
            var saveAppointmentTask = new SaveAppointmentTask()
            {
                Subject = saveAppointmentServiceParams.Subject,
                Details = saveAppointmentServiceParams.Details,
                StartTime = saveAppointmentServiceParams.StartTime,
                EndTime = saveAppointmentServiceParams.EndTime,
            };

            if (saveAppointmentServiceParams.AppointmentStatus.HasValue)
            {
                saveAppointmentTask.AppointmentStatus = saveAppointmentServiceParams.AppointmentStatus.Value;
            }

            if (saveAppointmentServiceParams.IsAllDayEvent.HasValue)
            {
                saveAppointmentTask.IsAllDayEvent = saveAppointmentServiceParams.IsAllDayEvent.Value;
            }

            saveAppointmentTask.Show();
#else
            throw new NotSupportedException("This service is not supported in WP7");
#endif
        }
    }
}