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
                MyProtocolDescriptorViewModel = new DescriptorViewModel
                {
                    Title = "Protocol",
                    Description = "Below is the current protocol than can be run, tested, and analyzed.",
                },
                MyOutputDescriptorViewModel = new DescriptorViewModel
                {
                    Title = "Output",
                    Description = "Below is the current protocol output."
                }
            };

            // Set the DataContext
            DataContext = ViewModel;
        }
    }
}
