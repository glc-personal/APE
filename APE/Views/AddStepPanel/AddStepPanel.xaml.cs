using APE.ViewModels;
using APE.ViewModels.Shared;
using System.Windows.Controls;

namespace APE.Views.AddStepPanel
{
    /// <summary>
    /// Interaction logic for AddStepPanel.xaml
    /// </summary>
    public partial class AddStepPanel : UserControl
    {
        public AddStepPanelViewModel ViewModel { get; set; }
        public AddStepPanel()
        {
            InitializeComponent();

            // Setup the view model
            ViewModel = new AddStepPanelViewModel();

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
