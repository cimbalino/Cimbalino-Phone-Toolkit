// ****************************************************************************
// <copyright file="SaveAppointmentAction.cs" company="Pedro Lamas">
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

using System;
using System.Windows;
using System.Windows.Interactivity;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.UserData;

namespace Cimbalino.Phone.Toolkit.Actions
{
    /// <summary>
    /// Represents an attachable object capable of launching the calendar application with a new appointment displayed. Use this to allow users to add an appointment to their calendar from your application.
    /// </summary>
    public class SaveAppointmentAction : TriggerAction<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the subject that will be set for the new appointment when the Calendar application is launched.
        /// </summary>
        /// <value>The subject that will be set for the new appointment when the Calendar application is launched.</value>
        public string Subject
        {
            get { return (string)GetValue(SubjectProperty); }
            set { SetValue(SubjectProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Subject" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SubjectProperty =
            DependencyProperty.Register("Subject", typeof(string), typeof(SaveAppointmentAction), null);

        /// <summary>
        /// Gets or sets the details text that will be set for the new appointment when the Calendar application is launched.
        /// </summary>
        /// <value>The details text that will be set for the new appointment when the Calendar application is launched.</value>
        public string Details
        {
            get { return (string)GetValue(DetailsProperty); }
            set { SetValue(DetailsProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Details" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DetailsProperty =
            DependencyProperty.Register("Details", typeof(string), typeof(SaveAppointmentAction), null);

        /// <summary>
        /// Gets or sets the start time that will be set for the new appointment when the Calendar application is launched.
        /// </summary>
        /// <value>The start time that will be set for the new appointment when the Calendar application is launched.</value>
        public DateTime? StartTime
        {
            get { return (DateTime?)GetValue(StartTimeProperty); }
            set { SetValue(StartTimeProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="StartTime" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty StartTimeProperty =
            DependencyProperty.Register("StartTime", typeof(DateTime?), typeof(SaveAppointmentAction), null);

        /// <summary>
        /// Gets or sets the end time for the new appointment when the Calendar application is launched.
        /// </summary>
        /// <value>The end time for the new appointment when the Calendar application is launched.</value>
        public DateTime? EndTime
        {
            get { return (DateTime?)GetValue(EndTimeProperty); }
            set { SetValue(EndTimeProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="EndTime" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty EndTimeProperty =
            DependencyProperty.Register("EndTime", typeof(DateTime?), typeof(SaveAppointmentAction), null);

        /// <summary>
        /// Gets or sets the appointment status that will be set for the new appointment when the Calendar application is launched.
        /// </summary>
        /// <value>The appointment status that will be set for the new appointment when the Calendar application is launched.</value>
        public AppointmentStatus AppointmentStatus
        {
            get { return (AppointmentStatus)GetValue(AppointmentStatusProperty); }
            set { SetValue(AppointmentStatusProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="AppointmentStatus" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty AppointmentStatusProperty =
            DependencyProperty.Register("AppointmentStatus", typeof(AppointmentStatus), typeof(SaveAppointmentAction), null);

        /// <summary>
        /// Gets or sets a value indicating whether the new appointment shown when the Calendar application is launched is an all day event.
        /// </summary>
        /// <value>true if the new appointment shown when the Calendar application is launched is an all day event; otherwise, false.</value>
        public bool IsAllDayEvent
        {
            get { return (bool)GetValue(IsAllDayEventProperty); }
            set { SetValue(IsAllDayEventProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="IsAllDayEvent" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsAllDayEventProperty =
            DependencyProperty.Register("IsAllDayEvent", typeof(bool), typeof(SaveAppointmentAction), null);

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
            new SaveAppointmentTask()
            {
                Subject = Subject,
                Details = Details,
                StartTime = StartTime,
                EndTime = EndTime,
                IsAllDayEvent = IsAllDayEvent,
                AppointmentStatus = AppointmentStatus
            }.Show();
        }
    }
}