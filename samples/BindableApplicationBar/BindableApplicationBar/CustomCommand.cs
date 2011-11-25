using System;
using System.Windows.Input;

namespace BindableApplicationBar
{
    public class CustomCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        #region Properties

        public Action Command { get; private set; }

        public Func<bool> CommandCanExecute { get; private set; }

        #endregion

        public CustomCommand(Action command)
            : this(command, null)
        {
        }

        public CustomCommand(Action command, Func<bool> commandCanExecute)
        {
            Command = command;
            CommandCanExecute = commandCanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return CommandCanExecute == null || CommandCanExecute();
        }

        public void Execute(object parameter)
        {
            if (Command != null && CanExecute(parameter))
            {
                Command();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            var canExecuteChanged = CanExecuteChanged;

            if (canExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }

    public class CustomCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        #region Properties

        public Action<T> Command { get; private set; }

        public Func<T, bool> CommandCanExecute { get; private set; }

        #endregion

        public CustomCommand(Action<T> command)
            : this(command, null)
        {
        }

        public CustomCommand(Action<T> command, Func<T, bool> commandCanExecute)
        {
            Command = command;
            CommandCanExecute = commandCanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return CommandCanExecute == null || CommandCanExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            if (Command != null && CanExecute(parameter))
            {
                Command((T)parameter);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            var canExecuteChanged = CanExecuteChanged;

            if (canExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}