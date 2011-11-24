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

        /// <summary>
        /// Launches and displays the <see cref="ChooserBase{TTaskEventArgs}"/>.
        /// </summary>
        public void Show()
        {
            _chooser.Show();
        }

        private void Chooser_Completed(object sender, TTaskEventArgs e)
        {
            _chooser.Completed -= Chooser_Completed;

            _resultAction(e);
        }
    }
}