using APE.ViewModels.Shared;
using System.Windows.Controls;

namespace APE.Views.Shared
{
    /// <summary>
    /// Interaction logic for DiscreteProgressBar.xaml
    /// </summary>
    public partial class DiscreteProgressBar : UserControl
    {
        public DiscreteProgressBarViewModel ViewModel { get; set; }
        public DiscreteProgressBar()
        {
            InitializeComponent();

            // Set the Data Context
            DataContext = ViewModel;
        }
    }
}
