using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NWind.ViewModel
{
    public class CommandDelegate : ICommand
    {
        Action<object> ExecuteDelegate;
        Func<object, bool> CanExecuteDelegate;

        public CommandDelegate(Func<object, bool> canExecuteDelegate, Action<object> executeDelegate)
        {
            this.CanExecuteDelegate = canExecuteDelegate;
            this.ExecuteDelegate = executeDelegate;
        }

        public event EventHandler CanExecuteChanged;

        public void ChangeCanExecute()
        {
            var handler = CanExecuteChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            var handler = CanExecuteDelegate;
            bool result = false;

            if (handler != null)
            {
                result = handler(parameter);
            }

            return result;
        }

        public void Execute(object parameter)
        {
            var handler = ExecuteDelegate;
            handler?.Invoke(parameter);
        }

    }
}
