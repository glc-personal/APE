using APE.ViewModels.AddStepWindow;
using APE.ViewModels.Shared;
using System.Windows;

namespace APE.Views.AddStepWindow
{
    /// <summary>
    /// Interaction logic for AddStepWindow.xaml
    /// </summary>
    public partial class AddStepWindow : Window
    {
        public AddStepWindowViewModel ViewModel { get; set; }
        public AddStepWindow()
        {
            InitializeComponent();

            // Setup the view model
            ViewModel = new AddStepWindowViewModel();

            // Setup the Banner
            ViewModel.MyBannerViewModel = new BannerViewModel
            {
                Title = "Add Step",
                Description = "Add specific protocol steps to your protocol.",
                IconPath = "pack://application:,,,/Resources/add-step-icon.png"
            };

            // Setup the Liquid Handling steps descriptor
            ViewModel.MyLiquidHandlingStepsDescriptorViewModel = new DescriptorViewModel
            {
                Title = "Liquid Handling Steps",
                Description = "Steps relating to liquid handling actions."
            };

            // Setup the Duration steps descriptor
            ViewModel.MyDurationStepsDescriptorViewModel = new DescriptorViewModel
            {
                Title = "Duration Steps",
                Description = "Steps relating to duration actions."
            };

            // Setup the Gantry steps descriptor
            ViewModel.MyGantryStepsDescriptorViewModel = new DescriptorViewModel
            {
                Title = "Gantry Step",
                Description = "Steps relating to gantry actions."
            };

            // Setup the Reader steps descriptor
            ViewModel.MyReaderStepsDescriptorViewModel = new DescriptorViewModel
            {
                Title = "Reader Steps",
                Description = "Steps relating to reader actions."
            };

            // Set the data context
            DataContext = ViewModel;
        }
    }
}
