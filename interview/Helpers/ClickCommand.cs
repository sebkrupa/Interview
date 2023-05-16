using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace interview.Helpers
{
    public class ClickCommand : ICommand
    {
        private Action _action;
        private Func<bool> _canHandle;

        public ClickCommand(Action action, Func<bool> canHandle)
        {
            _action = action;
            _canHandle = canHandle;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _canHandle.Invoke();
        }

        public void Execute(object? parameter)
        {
            _action();
        }
    }
}
