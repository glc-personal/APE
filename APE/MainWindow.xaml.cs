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
                },
                PauseIconButton = new IconButtonViewModel
                {
                    IconPath = "pack://application:,,,/Resources/pause-icon.png",
                    Command = ViewModel.PauseCommand,
                },
                StopIconButton = new IconButtonViewModel
                {
                    IconPath = "pack://application:,,,/Resources/stop-icon.png",
                    Command = ViewModel.StopCommand,
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

            // Set the DataContext
            DataContext = ViewModel;
        }
    }
}
