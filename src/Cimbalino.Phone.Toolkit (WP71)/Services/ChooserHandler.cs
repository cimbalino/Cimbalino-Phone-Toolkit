// ****************************************************************************
// <copyright file="ChooserHandler.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>20-11-2011</date>
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
    /// Manages a <see cref="ChooserBase{TTaskEventArgs}"/> class.
    /// </summary>
    /// <typeparam name="TTaskEventArgs">The <see cref="TaskEventArgs"/>.</typeparam>
    public class ChooserHandler<TTaskEventArgs>
        where TTaskEventArgs : TaskEventArgs
    {
        private readonly ChooserBase<TTaskEventArgs> _chooser;
        private readonly Action<TTaskEventArgs> _resultAction;
#if WP8
        private readonly TaskCompletionSource<TTaskEventArgs> _taskCompletionSource;
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="ChooserHandler{TTaskEventArgs}" /> class.
        /// </summary>
        /// <param name="chooser">The <see cref="ChooserBase{TTaskEventArgs}"/> to show.</param>
        /// <param name="resultAction">The <see cref="Action{TTaskEventArgs}"/> to be called once the operation is finished.</param>
        public ChooserHandler(ChooserBase<TTaskEventArgs> chooser, Action<TTaskEventArgs> resultAction)
        {
            _chooser = chooser;
            _resultAction = resultAction;

            _chooser.Completed += Chooser_Completed;
        }

#if WP8
        /// <summary>
        /// Initializes a new instance of the <see cref="ChooserHandler{TTaskEventArgs}" /> class.
        /// </summary>
        /// <param name="chooser">The <see cref="ChooserBase{TTaskEventArgs}"/> to show.</param>
        public ChooserHandler(ChooserBase<TTaskEventArgs> chooser)
        {
            _chooser = chooser;
            _chooser.Completed += Chooser_Completed;

            _taskCompletionSource = new TaskCompletionSource<TTaskEventArgs>();
        }
#endif

        /// <summary>
        /// Launches and displays the <see cref="ChooserBase{TTaskEventArgs}"/>.
        /// </summary>
        public void Show()
        {
            _chooser.Show();
        }

#if WP8
        /// <summary>
        /// Launches and displays the <see cref="ChooserBase{TTaskEventArgs}"/>.
        /// </summary>
        /// <returns>The <see cref="Task{TTaskEventArgs}"/> object representing the asynchronous operation.</returns>
        public Task<TTaskEventArgs> ShowTaskAsync()
        {
            _chooser.Show();

            return _taskCompletionSource.Task;
        }
#endif

        private void Chooser_Completed(object sender, TTaskEventArgs e)
        {
            _chooser.Completed -= Chooser_Completed;

            if (_resultAction != null)
            {
                _resultAction(e);
            }
#if WP8
            else
            {
                _taskCompletionSource.SetResult(e);
            }
#endif
        }
    }
}