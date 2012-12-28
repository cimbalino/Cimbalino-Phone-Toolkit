// ****************************************************************************
// <copyright file="SaveAppointmentServiceParams.cs" company="Pedro Lamas">
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

using System;
using Microsoft.Phone.UserData;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// The settings to be used when <see cref="SaveAppointmentService.Show"/> is invoked.
    /// </summary>
    public class SaveAppointmentServiceParams
    {
        /// <summary>
        /// Gets or sets the subject that will be set for the new appointment when the Calendar application is launched.
        /// </summary>
        /// <value>The subject that will be set for the new appointment when the Calendar application is launched.</value>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the details text that will be set for the new appointment when the Calendar application is launched.
        /// </summary>
        /// <value>The details text that will be set for the new appointment when the Calendar application is launched.</value>
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets the start time that will be set for the new appointment when the Calendar application is launched.
        /// </summary>
        /// <value>The start time that will be set for the new appointment when the Calendar application is launched.</value>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time for the new appointment when the Calendar application is launched.
        /// </summary>
        /// <value>The end time for the new appointment when the Calendar application is launched.</value>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the new appointment shown when the Calendar application is launched is an all day event.
        /// </summary>
        /// <value>true if the new appointment shown when the Calendar application is launched is an all day event; otherwise, false.</value>
        public bool? IsAllDayEvent { get; set; }

        /// <summary>
        /// Gets or sets the appointment status that will be set for the new appointment when the Calendar application is launched.
        /// </summary>
        /// <value>The appointment status that will be set for the new appointment when the Calendar application is launched.</value>
        public AppointmentStatus? AppointmentStatus { get; set; }

        /// <summary>
        /// Gets or sets the location string that will be set for the new appointment when the Calendar application is launched.
        /// </summary>
        /// <value>The location string that will be set for the new appointment when the Calendar application is launched.</value>
        public string Location { get; set; }
    }
}