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
        private string buttonWidth { get; set; }
        private string buttonHeight { get; set; }
        private string iconWidth { get; set; }
        private string iconHeight { get; set; }
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
        public string ButtonWidth
        {
            get => buttonWidth;
            set
            {
                buttonWidth = value;
                OnPropertyChanged(nameof(ButtonWidth));
            }
        }
        public string ButtonHeight
        {
            get => buttonHeight;
            set
            {
                buttonHeight = value;
                OnPropertyChanged(nameof(ButtonHeight)); 
            }
        }
        public string IconWidth
        {
            get => iconWidth;
            set
            {
                iconWidth = value;
                OnPropertyChanged(nameof(IconWidth));
            }
        }
        public string IconHeight
        {
            get => iconHeight;
            set
            {
                iconHeight = value;
                OnPropertyChanged(nameof(IconHeight));
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
