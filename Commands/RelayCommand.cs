using System.Windows.Input;

namespace SearchSystem.Commands
{
    class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Predicate<object> _CanExecute { get; set; }

        private Action<object> _Execute { get; set; }

        public RelayCommand(Predicate<object> CanExecuteMethod, Action<object> ExecuteMethod)
        {
            _CanExecute = CanExecuteMethod;
            _Execute = ExecuteMethod;
        }

        public bool CanExecute(object? parameter)
        {
            return _CanExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _Execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
