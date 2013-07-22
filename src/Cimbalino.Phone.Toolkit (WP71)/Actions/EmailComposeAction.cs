// ****************************************************************************
// <copyright file="EmailComposeAction.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>05-06-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.ComponentModel;
using System.Windows;
using System.Windows.Interactivity;
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Actions
{
    /// <summary>
    /// Represents an attachable object capable of sending e-mail messages.
    /// </summary>
    public class EmailComposeAction : TriggerAction<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the e-mail recipients.
        /// </summary>
        /// <value>The e-mail recipients.</value>
        [Category("Common")]
        public string To
        {
            get { return (string)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="To" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ToProperty =
            DependencyProperty.Register("To", typeof(string), typeof(EmailComposeAction), null);

        /// <summary>
        /// Gets or sets the e-mail CC recipients.
        /// </summary>
        /// <value>The e-mail CC recipients.</value>
        public string Cc
        {
            get { return (string)GetValue(CcProperty); }
            set { SetValue(CcProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Cc" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CcProperty =
            DependencyProperty.Register("Cc", typeof(string), typeof(EmailComposeAction), null);

        /// <summary>
        /// Gets or sets the e-mail BCC recipients.
        /// </summary>
        /// <value>The e-mail BCC recipients.</value>
        public string Bcc
        {
            get { return (string)GetValue(BccProperty); }
            set { SetValue(BccProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Bcc" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BccProperty =
            DependencyProperty.Register("Bcc", typeof(string), typeof(EmailComposeAction), null);

        /// <summary>
        /// Gets or sets the e-mail subject.
        /// </summary>
        /// <value>The e-mail subject.</value>
        [Category("Common")]
        public string Subject
        {
            get { return (string)GetValue(SubjectProperty); }
            set { SetValue(SubjectProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Subject" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SubjectProperty =
            DependencyProperty.Register("Subject", typeof(string), typeof(EmailComposeAction), null);

        /// <summary>
        /// Gets or sets the e-mail body.
        /// </summary>
        /// <value>The e-mail body.</value>
        [Category("Common")]
        public string Body
        {
            get { return (string)GetValue(BodyProperty); }
            set { SetValue(BodyProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Body" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BodyProperty =
            DependencyProperty.Register("Body", typeof(string), typeof(EmailComposeAction), null);

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
            new EmailComposeTask()
            {
                To = To,
                Cc = Cc,
                Bcc = Bcc,
                Subject = Subject,
                Body = Body
            }.Show();
        }
    }
}