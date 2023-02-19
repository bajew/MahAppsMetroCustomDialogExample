using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MahAppsMetroCustomDialogExample
{
    public class RelayCommand : ICommand
    {
        Action action;
        Action<object> action2; 
        public RelayCommand(Action action)
        {
            this.action = action;
            this.action2 = (o) => { action?.Invoke(); };
        }
        public RelayCommand(Action<object> action)
        {
            this.action2 = action;
            this.action = () => { action2?.Invoke(null); };
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true; 
        }

        public void Execute(object? parameter)
        {
            if (parameter == null)
            {
                action?.Invoke();
            }
            else
            {
                action2?.Invoke(parameter);
            }
        }
    }
}
