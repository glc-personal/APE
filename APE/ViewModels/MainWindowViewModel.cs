using APE.Commands;
using APE.ViewModels.Shared;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace APE.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        /*
         * ----------------------------------------------------------------------------------------------------------------
         * Private Attributes
         * ----------------------------------------------------------------------------------------------------------------
         */
        private string status;
        private string linkIconPath;
        private string currentTime;
        private string currentDate;
        private Timer timer;
        private ICommand playCommand;
        private ICommand pauseCommand;
        private ICommand stopCommand;

        /*
         * --------------------------------------------------------------------------------------------------------
         * Main Content
         * --------------------------------------------------------------------------------------------------------
         */
        public BannerViewModel MyBannerViewModel { get; set; }
        public InfoStampViewModel MyProtocolInfoStampViewModel { get; set; }
        public InfoStampViewModel MyShortDescriptionInfoStampViewModel { get; set; }
        public InfoStampViewModel MyAuthorInfoStampViewModel { get; set; }
        public InfoStampViewModel MyStatusInfoStampViewModel { get; set; }
        public InfoStampViewModel MyCoordinatesInfoStampViewModel { get; set; }
        public InfoStampViewModel MyReagentsInfoStampViewModel { get; set; }
        public InfoStampViewModel MyTipBoxMappingInfoStampViewModel { get; set; }
        public InfoStampViewModel MyVersionInfoStampViewModel { get; set; }
        public DiscreteProgressBarViewModel MyDiscreteProgressBarViewModel { get; set; }
        public DescriptorViewModel MyProtocolDescriptorViewModel { get; set; }

        /*
         * ----------------------------------------------------------------------------------------------------------------
         * Commands
         * ----------------------------------------------------------------------------------------------------------------
         */
        public ICommand PlayCommand
        {
            get
            {
                if (playCommand == null)
                {
                    playCommand = new RelayCommand(ExecutePlayCommand, CanExecutePlayCommand);
                }
                return playCommand;
            }
        }
        private void ExecutePlayCommand(object parameter)
        {
            MessageBox.Show("Play");
        }
        private bool CanExecutePlayCommand(object parameter)
        {
            // Logic for checking if the play command can be executed
            return true;
        }

        public ICommand PauseCommand
        {
            get
            {
                if (pauseCommand == null)
                {
                    pauseCommand = new RelayCommand(ExecutePauseCommand, CanExecutePauseCommand);
                }
                return pauseCommand;
            }
        }
        private void ExecutePauseCommand(object parameter)
        {
            MessageBox.Show("Pause");
        }
        private bool CanExecutePauseCommand(object parameter)
        {
            // Logic for if the pause command can be exectured
            return true;
        }
        public ICommand StopCommand
        {
            get
            {
                if (stopCommand == null)
                {
                    stopCommand = new RelayCommand(ExecuteStopCommand, CanExecuteStopCommand);
                }
                return stopCommand;
            }
        }
        public void ExecuteStopCommand(object parameter)
        {
            MessageBox.Show("Stop");
        }
        public bool CanExecuteStopCommand(object parameter)
        {
            // Logic for if the stop command can be execute
            return true;
        }

        /*
         * ----------------------------------------------------------------------------------------------------------------
         * Constructor
         * ----------------------------------------------------------------------------------------------------------------
         */
        public MainWindowViewModel()
        {
            // Setup the timer
            timer = new Timer(1000); // Update every 1 second
            timer.Elapsed += TimerElapsed;
            timer.Start();

            // Setup the Status Bar
            status = "Ready";
            linkIconPath = "pack://application:,,,/Resources/unlinked-icon.png";
            currentTime = DateTime.Now.ToString("hh:mm tt");
            currentDate = DateTime.Now.ToString("M/d/yyyy");
        }

        /*
         * ----------------------------------------------------------------------------------------------------------------
         * Properties
         * ----------------------------------------------------------------------------------------------------------------
         */
        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        public string LinkIconPath
        {

            get => linkIconPath;
            set
            {
                linkIconPath = value;
                OnPropertyChanged(nameof(LinkIconPath));
            }
        }
        public string CurrentTime
        {
            get => currentTime;
            set
            {
                currentTime = value;
                OnPropertyChanged(nameof(CurrentTime));
            }
        }
        public string CurrentDate
        {
            get => currentDate;
            set
            {
                currentDate = value;
                OnPropertyChanged(nameof(CurrentDate));
            }
        }

        /*
         * ----------------------------------------------------------------------------------------------------------------
         * Status Bar Private Methods
         * ----------------------------------------------------------------------------------------------------------------
         */
        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("hh:mm tt");
            CurrentDate = DateTime.Now.ToString("M/d/yyyy");
        }

        /*
         * ----------------------------------------------------------------------------------------------------------------
         * INotifyPropertyChanged Members
         * ----------------------------------------------------------------------------------------------------------------
         */
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
