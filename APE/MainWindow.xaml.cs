using APE.ViewModels;
using System.Windows;
using APE.ViewModels.Shared;

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
            ViewModel = new MainWindowViewModel
            {
                MyBannerViewModel = new BannerViewModel
                {
                    Title = "Protocol Editor",
                    Description = "Create, edit, and run protocols for assay development.",
                    IconPath = "pack://application:,,,/Resources/protocol-editor-icon.png"
                },
                MyProtocolInfoStampViewModel = new InfoStampViewModel
                {
                    Title = "Protocol",
                    Description = "ICP7"
                },
                MyShortDescriptionInfoStampViewModel = new InfoStampViewModel
                {
                    Title = "Short Description",
                    Description = "Integration checkpoint protocol"
                },
                MyAuthorInfoStampViewModel = new InfoStampViewModel
                {
                    Title = "Author",
                    Description = "glc-biorad"
                },
                MyStatusInfoStampViewModel = new InfoStampViewModel
                {
                    Title = "Status",
                    Description = "Transfer Reagent - (Elution Buffer)"
                },
                MyCoordinatesInfoStampViewModel = new InfoStampViewModel
                {
                    Title = "Coordiantes",
                    Description = "ICP7 - A"
                },
                MyReagentsInfoStampViewModel = new InfoStampViewModel
                {
                    Title = "Reagents",
                    Description = "ICP7"
                },
                MyTipBoxMappingInfoStampViewModel = new InfoStampViewModel
                {
                    Title = "Tip Box Mapping",
                    Description = "ICP7"
                },
                MyVersionInfoStampViewModel = new InfoStampViewModel
                {
                    Title = "Version",
                    Description = "1.2.7",
                },
                MyProtocolDescriptorViewModel = new DescriptorViewModel
                {
                    Title = "Protocol",
                    Description = "Below is the current protocol than can be run, tested, and analyzed.",
                },
            };

            // Set the DataContext
            DataContext = ViewModel;
        }
    }
}
