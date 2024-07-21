using APE.ViewModels;
using System.Windows;
using System.Collections.ObjectModel;
using APE.ViewModels.Shared;
using System.Windows.Media;
using System;

namespace APE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            // Setup the view model
            ViewModel = new MainWindowViewModel();
            ViewModel.MyBannerViewModel = new BannerViewModel
            {
                Title = "Protocol Editor",
                Description = "Create, edit, and run protocols for assay development.",
                IconPath = "pack://application:,,,/Resources/protocol-editor-icon.png"
            };
            ViewModel.MyAddIconButtonViewModel = new IconButtonViewModel
            {
                IconPath = "pack://application:,,,/Resources/left-arrow-icon.png",
                Command = ViewModel.ToggleAddStepPanelCommand,
                ButtonWidth = "20",
                ButtonHeight = "20",
                IconWidth = "10",
                IconHeight = "10"
            };
            ViewModel.MyProtocolInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Protocol",
                Description = "-"
            };
            ViewModel.MyShortDescriptionInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Short Description",
                Description = "No protocol loaded"
            };
            ViewModel.MyAuthorInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Author",
                Description = "-"
            };
            ViewModel.MyStatusInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Status",
                Description = "Ready"
            };
            ViewModel.MyCoordinatesInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Coordiantes",
                Description = "ICP7 - A"
            };
            ViewModel.MyReagentsInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Reagents",
                Description = "ICP7"
            };
            ViewModel.MyTipBoxMappingInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Tip Box Mapping",
                Description = "ICP7"
            };
            ViewModel.MyVersionInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Version",
                Description = "N/A",
            };
            ViewModel.MyDiscreteProgressBarViewModel = new DiscreteProgressBarViewModel(numberOfBars: 1)
            {
                PlayIconButton = new IconButtonViewModel
                {
                    IconPath = "pack://application:,,,/Resources/play-icon.png",
                    Command = ViewModel.PlayCommand,
                    ButtonWidth = "50",
                    ButtonHeight = "50",
                    IconWidth = "40",
                    IconHeight = "40"
                },
                PauseIconButton = new IconButtonViewModel
                {
                    IconPath = "pack://application:,,,/Resources/pause-icon.png",
                    Command = ViewModel.PauseCommand,
                    ButtonWidth = "50",
                    ButtonHeight = "50",
                    IconWidth = "40",
                    IconHeight = "40"
                },
                StopIconButton = new IconButtonViewModel
                {
                    IconPath = "pack://application:,,,/Resources/stop-icon.png",
                    Command = ViewModel.StopCommand,
                    ButtonWidth = "50",
                    ButtonHeight = "50",
                    IconWidth = "40",
                    IconHeight = "40"
                },
            };
            ViewModel.MyProtocolDescriptorViewModel = new DescriptorViewModel
            {
                Title = "Protocol",
                Description = "Below is the current protocol than can be run, tested, and analyzed.",
            };
            ViewModel.Status = "Ready";
            ViewModel.LinkIconPath = "pack://application:,,,/Resources/unlinked-black-icon.png";
            ViewModel.CurrentTime = DateTime.Now.ToString("hh:mm:ss tt");
            ViewModel.CurrentDate = DateTime.Now.ToString("M/d/yyyy");
            ViewModel.StatusBarBackground = Brushes.LightGray;
            ViewModel.StatusBarForeground = Brushes.Black;
            ViewModel.MyAddStepPanelViewModel = new AddStepPanelViewModel();

            // Set the DataContext
            DataContext = ViewModel;
        }

        /// <summary>
        /// Toggle the Add Step Panel 
        /// </summary>
        public void ToggleAddStepPanel()
        {
            if (MainWindowAddStepPanel.Width.Value == 0)
            {
                MainWindowAddStepPanel.Width = new GridLength(3, GridUnitType.Star);
                MainWindowMainContent.Width = new GridLength(7, GridUnitType.Star);
            }
            else
            {
                MainWindowAddStepPanel.Width = new GridLength(0, GridUnitType.Star);
                MainWindowMainContent.Width = new GridLength(10, GridUnitType.Star);
            }
        }
    }
}
