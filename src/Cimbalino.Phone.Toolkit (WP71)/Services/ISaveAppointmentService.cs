// ****************************************************************************
// <copyright file="ISaveAppointmentService.cs" company="Pedro Lamas">
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

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching the calendar application with a new appointment displayed. Use this to allow users to add an appointment to their calendar from your application.
    /// </summary>
    public interface ISaveAppointmentService
    {
        /// <summary>
        /// Shows the calendar application with a new appointment displayed, using the specified <see cref="SaveAppointmentServiceParams"/> instance.
        /// </summary>
        /// <param name="saveAppointmentServiceParams">The <see cref="SaveAppointmentServiceParams"/> instance.</param>
        void Show(SaveAppointmentServiceParams saveAppointmentServiceParams);
    }
}