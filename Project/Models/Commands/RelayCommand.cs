using System;
using System.Windows.Input;

namespace Project.Models
{
    public class RelayCommand : ICommand
    {
        private Action<Object> execute;

        private Func<Object, Boolean> canExecute;

        public RelayCommand(Action<Object> execute, Func<Object, Boolean> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public Boolean CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
