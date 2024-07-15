using System.Windows.Input;

namespace APE.Commands
{
    public interface IRelayCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
