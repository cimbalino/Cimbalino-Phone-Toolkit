// ****************************************************************************
// <copyright file="DispatcherExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>14-12-2011</date>
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
using System.Windows.Threading;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="Dispatcher"/> instances.
    /// </summary>
    public static class DispatcherExtensions
    {
        /// <summary>
        /// Executes the specified action asynchronously on the thread the Dispatcher is associated with, after the specified timeout.
        /// </summary>
        /// <param name="dispatcher">The dispatcher instance.</param>
        /// <param name="timeout">The amount of time to delay before the action is invoked.</param>
        /// <param name="action">The <see cref="Action"/> to execute.</param>
        public static void BeginInvokeAfterTimeout(this Dispatcher dispatcher, double timeout, Action action)
        {
            dispatcher.BeginInvokeAfterTimeout(TimeSpan.FromMilliseconds(timeout), action);
        }

        /// <summary>
        /// Executes the specified action asynchronously on the thread the Dispatcher is associated with, after the specified timeout.
        /// </summary>
        /// <param name="dispatcher">The dispatcher instance.</param>
        /// <param name="timeout">The <see cref="TimeSpan"/> representing the amount of time to delay before the action is invoked.</param>
        /// <param name="action">The <see cref="Action"/> to execute.</param>
        public static void BeginInvokeAfterTimeout(this Dispatcher dispatcher, TimeSpan timeout, Action action)
        {
            var dispatcherTimer = new DispatcherTimer()
            {
                Interval = timeout
            };

            EventHandler timerTickEventHandler = null;

            timerTickEventHandler = (s, e) =>
            {
                dispatcherTimer.Tick -= timerTickEventHandler;

                dispatcherTimer.Stop();

                dispatcher.BeginInvoke(action);
            };

            dispatcherTimer.Tick += timerTickEventHandler;

            dispatcherTimer.Start();
        }

#if WP8
        /// <summary>
        /// Retrieves a <see cref="TaskScheduler"/> instance for the thread the Dispatcher is associated with.
        /// </summary>
        /// <param name="dispatcher">The dispatcher instance.</param>
        /// <returns>A <see cref="TaskScheduler"/> instance for the thread the Dispatcher is associated with.</returns>
        public static Task<TaskScheduler> ToTaskSchedulerAsync(this Dispatcher dispatcher)
        {
            var taskCompletionSource = new TaskCompletionSource<TaskScheduler>();

            dispatcher.BeginInvoke(() =>
            {
                try
                {
                    var synchronizationContext = TaskScheduler.FromCurrentSynchronizationContext();

                    taskCompletionSource.SetResult(synchronizationContext);
                }
                catch (Exception ex)
                {
                    taskCompletionSource.SetException(ex);
                }
            });

            return taskCompletionSource.Task;
        }
#endif
    }
}