using System.Windows.Input;

namespace CarnetDepenses.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _exec;
        private readonly Func<bool> _canExec;

        public RelayCommand(Action<object> exec, Func<bool> canExec = null)
        {
            _exec = exec;
            _canExec = canExec;
        }

        public bool CanExecute(object p) => _canExec == null || _canExec();
        public void Execute(object p) => _exec(p);
        public event EventHandler CanExecuteChanged;

        public void Rafraichir()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
