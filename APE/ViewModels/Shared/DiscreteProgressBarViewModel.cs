using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace APE.ViewModels.Shared
{
    public class DiscreteProgressBarViewModel : INotifyPropertyChanged
    {
        /*
         * --------------------------------------------------------------------------------------------------------
         * Private Attributes
         * --------------------------------------------------------------------------------------------------------
         */
        private ObservableCollection<ProgressBarViewModel> progressBars;

        /*
         * --------------------------------------------------------------------------------------------------------
         * Public Attributes
         * --------------------------------------------------------------------------------------------------------
         */

        public IconButtonViewModel PlayIconButton { get; set; }
        public IconButtonViewModel PauseIconButton { get; set; }
        public IconButtonViewModel StopIconButton { get; set; }
        public ObservableCollection<ProgressBarViewModel> ProgressBars
        {
            get => progressBars;
            set
            {
                progressBars = value;
                OnPropertyChange(nameof(ProgressBars));
            }
        }

        /*
         * --------------------------------------------------------------------------------------------------------
         * Constructor
         * --------------------------------------------------------------------------------------------------------
         */
        public DiscreteProgressBarViewModel() { }
        public DiscreteProgressBarViewModel(int numberOfBars = 1)
        {
            // Initialize the collection of progress bars
            ProgressBars = new ObservableCollection<ProgressBarViewModel>();
            for (int i = 0; i < numberOfBars; i++)
            {
                ProgressBars.Add(new ProgressBarViewModel
                {
                    IsCompleted = false,
                    CornerRadius = new CornerRadius(5)
                });
            }
        }

        /*
         * --------------------------------------------------------------------------------------------------------
         * INotifyPropertyChanged Methods
         * --------------------------------------------------------------------------------------------------------
         */
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
