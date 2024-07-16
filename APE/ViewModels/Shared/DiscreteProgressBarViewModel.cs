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
        public DiscreteProgressBarViewModel() 
        {
            // Initialize the collection of progress bars
            double R = ProgressBarViewModel.Radius;
            ProgressBars = new ObservableCollection<ProgressBarViewModel>();
            ProgressBars.Add(new ProgressBarViewModel
            {
                IsCompleted = false,
                CornerRadius = new CornerRadius(R, R, R, R)
            });
        }
        public DiscreteProgressBarViewModel(int numberOfBars = 1)
        {
            // Initialize the collection of progress bars
            double R = ProgressBarViewModel.Radius;
            ProgressBars = new ObservableCollection<ProgressBarViewModel>();
            for (int i = 0; i < numberOfBars; i++)
            {
                // Setup the corners
                double topLeft = 0;
                double topRight = 0;
                double bottomLeft = 0;
                double bottomRight = 0;
                // If there is only one bar, round all sides
                if (numberOfBars == 1)
                {
                    topLeft = R;
                    bottomLeft = R;
                    topRight = R;
                    bottomRight = R;
                }
                // Setup the progress bar corners
                else
                {
                    if (i == 0)
                    {
                        topLeft = R;
                        bottomLeft = R;
                    }
                    else if (i == numberOfBars - 1)
                    {
                        topRight = R;
                        bottomRight = R;
                    }
                }
                ProgressBars.Add(new ProgressBarViewModel
                {
                    IsCompleted = false,
                    CornerRadius = new CornerRadius(topLeft, topRight, bottomRight, bottomLeft)
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
