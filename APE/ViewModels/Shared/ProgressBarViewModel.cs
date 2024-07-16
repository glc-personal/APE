using System.ComponentModel;
using System.Windows;

namespace APE.ViewModels.Shared
{
    public class ProgressBarViewModel : INotifyPropertyChanged
    {
        /*
         * --------------------------------------------------------------------------------------------------------
         * Private Attributes
         * --------------------------------------------------------------------------------------------------------
         */
        private bool isCompleted;
        private CornerRadius cornerRadius;

        /*
         * --------------------------------------------------------------------------------------------------------
         * Public Attributes
         * --------------------------------------------------------------------------------------------------------
         */
        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }
        public CornerRadius CornerRadius
        {
            get => cornerRadius;
            set
            {
                cornerRadius = value;
                OnPropertyChanged(nameof(CornerRadius));
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
