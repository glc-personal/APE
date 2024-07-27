using APE.Commands;
using APE.ViewModels.Shared;
using System;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Prism.Events;
using Prism.Commands;
using APE.UIEvents;
using APE.ViewModels.StepContent;

namespace APE.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;

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
        private ICommand toggleAddStepPanelCommand;

        private Brush statusBarBackground;
        private Brush statusBarForeground;
        private object stepContentObject;

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
        public StepContentViewModel MyStepContentViewModel { get; set; }

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
        public ICommand ToggleAddStepPanelCommand
        {
            get
            {
                if (toggleAddStepPanelCommand == null)
                {
                    toggleAddStepPanelCommand = new DelegateCommand(ExecuteToggleAddStepPanelCommand);
                }
                return toggleAddStepPanelCommand;
            }
        }
        private void ExecuteToggleAddStepPanelCommand()
        {
            _eventAggregator.GetEvent<ToggleAddStepPanelEvent>().Publish();
        }

        /*
         * ----------------------------------------------------------------------------------------------------------------
         * Constructor
         * ----------------------------------------------------------------------------------------------------------------
         */
        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            // Setup the event aggregator
            _eventAggregator = eventAggregator;

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
        public object StepContentObject
        {
            get => stepContentObject;
            set
            {
                stepContentObject = value;
                OnPropertyChanged(nameof(StepContentObject));
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
         * Step Content Data Panel Setup Methods
         * ----------------------------------------------------------------------------------------------------------------
         */
        public void SetupStepContentDataPanel_AddSample()
        {
            StepContentObject = new AddSampleStepContentViewModel
            {
                MyStepContentViewModel = new StepContentViewModel
                {
                    MyBannerViewModel = new BannerViewModel
                    {
                        Title = "Add Sample",
                        Description = "Protocol step for adding a sample",
                        IconPath = "pack://application:,,,/Resources/Images/sample-icon.png"
                    },
                    MyDescriptorViewModel = new DescriptorViewModel
                    {
                        Title = "Add Sample",
                        Description = "Add a specific volume of sample to the corresponding Deep Well."
                    },
                    MyBatchTitledTextBoxViewModel = new TitledTextBoxViewModel
                    {
                        Title = "Batch",
                        DefaultText = "A",
                        TextBoxWidth = "50"
                    },
                    MyVolumeTitledTextBoxViewModel = new TitledTextBoxViewModel
                    {
                        Title = "Volume",
                        DefaultText = "1000",
                        TextBoxWidth = "50",
                    },
                    MySampleTypeTitledTextBoxViewModel = new TitledTextBoxViewModel
                    {
                        Title = "Sample Type",
                        DefaultText = "Plasma",
                        TextBoxWidth = "50",
                    },
                    MyRequiresNewTipsTitledTextBoxViewModel = new TitledTextBoxViewModel
                    {
                        Title = "Requires New Tips",
                        DefaultText = "Yes",
                        TextBoxWidth = "50",
                    }
                },
            };
        }

        public void SetupStepContentDataPanel_AddReagent()
        {
            StepContentObject = new AddReagentStepContentViewModel
            {
                MyStepContentViewModel = new StepContentViewModel
                {
                    MyBannerViewModel = new BannerViewModel
                    {
                        Title = "Add Reagent",
                        Description = "Protocol step for adding a reagent",
                        IconPath = "pack://application:,,,/Resources/Images/reagents-icon.png"
                    },
                    MyDescriptorViewModel = new DescriptorViewModel
                    {
                        Title = "Add Reagent",
                        Description = "Add a specific reagent volume to the provided location."
                    },
                    MyBatchTitledTextBoxViewModel = new TitledTextBoxViewModel
                    {
                        Title = "Batch",
                        DefaultText = "A",
                        TextBoxWidth = "50",
                    },
                    MyReagentTitledTextBoxViewModel = new TitledTextBoxViewModel
                    {
                        Title = "Reagent",
                        DefaultText = "Lysis Buffer",
                        TextBoxWidth = "150",
                    },
                    MyVolumeTitledTextBoxViewModel = new TitledTextBoxViewModel
                    {
                        Title = "Volume",
                        DefaultText = "100",
                        TextBoxWidth = "50",
                    },
                    MyDestinationTitledTextBoxViewModel = new TitledTextBoxViewModel
                    {
                        Title = "Destination",
                        DefaultText = "32 Deep Well",
                        TextBoxWidth = "150",
                    },
                    MyRequiresNewTipsTitledTextBoxViewModel = new TitledTextBoxViewModel
                    {
                        Title = "Requires New Tips",
                        DefaultText = "Yes",
                        TextBoxWidth = "50",
                    },
                },
            };
        }
    }
}
