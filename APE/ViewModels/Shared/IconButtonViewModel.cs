using System.ComponentModel;
using System.Windows.Input;

namespace APE.ViewModels.Shared
{
    public class IconButtonViewModel : INotifyPropertyChanged
    {
        /*
         * --------------------------------------------------------------------------------------------------------
         * Private Attributes
         * --------------------------------------------------------------------------------------------------------
         */
        private string iconPath { get; set; }
        private ICommand command { get; set; }

        /*
         * --------------------------------------------------------------------------------------------------------
         * Public Attributes
         * --------------------------------------------------------------------------------------------------------
         */
        public string IconPath
        {
            get => iconPath;
            set
            {
                iconPath = value;
                OnPropertyChanged(nameof(IconPath));
            }
        }
        public ICommand Command
        {
            get => command;
            set
            {
                command = value;
                OnPropertyChanged(nameof(Command));
            }
        }

        /*
         * --------------------------------------------------------------------------------------------------------
         * INotifyPropertyChanged Methods
         * --------------------------------------------------------------------------------------------------------
         */
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
