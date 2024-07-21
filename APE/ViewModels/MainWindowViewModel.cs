using APE.Commands;
using APE.ViewModels.Shared;
using APE.Views.AddStepWindow;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
        private ICommand addStepCommand;
        private ICommand toggleAddStepPanelCommand;
        private Brush statusBarBackground;
        private Brush statusBarForeground;

        /*
         * --------------------------------------------------------------------------------------------------------
         * Main Content
         * --------------------------------------------------------------------------------------------------------
         */
        public BannerViewModel MyBannerViewModel { get; set; }
        public IconButtonViewModel MyAddIconButtonViewModel { get; set; }
        public IconButtonViewModel MyCopyIconButtonViewModel { get; set; }
        public IconButtonViewModel MyCutIconButtonViewModel { get; set; }
        public IconButtonViewModel MyPasteIconButtonViewModel { get; set; }
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
        public AddStepPanelViewModel MyAddStepPanelViewModel { get; set; }

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
            Application.Current.Dispatcher.Invoke(() => {
                LinkIconPath = "pack://application:,,,/Resources/unlinked-white-icon.png";
                StatusBarBackground = Brushes.Purple;
                StatusBarForeground = Brushes.White;
            });
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
            Application.Current.Dispatcher.Invoke(() =>
            {
                LinkIconPath = "pack://application:,,,/Resources/unlinked-black-icon.png";
                StatusBarBackground = Brushes.Gold;
                StatusBarForeground = Brushes.Black;
            });            
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
            var result = MessageBox.Show("Are you sure you want to stop the protocol?",
                "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LinkIconPath = "pack://application:,,,/Resources/unlinked-black-icon.png";
                    StatusBarBackground = Brushes.LightGray;
                    StatusBarForeground = Brushes.Black;
                });
            }          
        }
        public bool CanExecuteStopCommand(object parameter)
        {
            // Logic for if the stop command can be execute
            return true;
        }
        public ICommand AddStepCommand
        {
            get
            {
                if (addStepCommand == null)
                {
                    addStepCommand = new RelayCommand(ExecuteAddStepCommand, CanExecuteAddStepCommand);
                }
                return addStepCommand;
            }
        }
        public void ExecuteAddStepCommand(object parameter)
        {
            // If protocol is not currently running (add ability to create a new protocol while one is running)
            APE.Views.AddStepWindow.AddStepWindow addStepWindow = new Views.AddStepWindow.AddStepWindow();
            addStepWindow.Show();
        }
        public bool CanExecuteAddStepCommand(object parameter)
        {
            // Logic for if the add step command can be executed
            return true;
        }
        public ICommand ToggleAddStepPanelCommand
        {
            get
            {
                if (toggleAddStepPanelCommand == null)
                {
                    toggleAddStepPanelCommand = new RelayCommand(ExecuteToggleAddStepPanelCommand,
                        CanExecuteToggleAddStepPanelCommand);
                }
                return toggleAddStepPanelCommand;
            }
        }
        private void ExecuteToggleAddStepPanelCommand(object parameter)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.ToggleAddStepPanel();
        }
        private bool CanExecuteToggleAddStepPanelCommand(object paramater)
        {
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
        public Brush StatusBarBackground
        {
            get => statusBarBackground;
            set
            {
                if (statusBarBackground != value)
                {
                    statusBarBackground = value;
                    OnPropertyChanged(nameof(StatusBarBackground));
                }
            }
        }
        public Brush StatusBarForeground
        {
            get => statusBarForeground;
            set
            {
                if (statusBarForeground != value)
                {
                    statusBarForeground = value;
                    OnPropertyChanged(nameof(StatusBarForeground));
                }               
            }
        }

        /*
         * ----------------------------------------------------------------------------------------------------------------
         * Status Bar Private Methods
         * ----------------------------------------------------------------------------------------------------------------
         */
        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("hh:mm:ss tt");
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
