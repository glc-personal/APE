using APE.ViewModels.Shared;
using System.ComponentModel;

namespace APE.ViewModels.AddStepWindow
{
    public class AddStepWindowViewModel : INotifyPropertyChanged
    {
        /*
         * ------------------------------------------------------------------------------------------------------
         * Private Attributes
         * ------------------------------------------------------------------------------------------------------
         */

        /*
         * ------------------------------------------------------------------------------------------------------
         * Public Attributes
         * ------------------------------------------------------------------------------------------------------
         */
        public BannerViewModel MyBannerViewModel { get; set; }
        public DescriptorViewModel MyLiquidHandlingStepsDescriptorViewModel { get; set; }
        public DescriptorViewModel MyDurationStepsDescriptorViewModel { get; set; }
        public DescriptorViewModel MyGantryStepsDescriptorViewModel { get; set; }
        public DescriptorViewModel MyReaderStepsDescriptorViewModel { get; set; }

        /*
         * ------------------------------------------------------------------------------------------------------
         * Commands
         * ------------------------------------------------------------------------------------------------------
         */

        /*
         * ------------------------------------------------------------------------------------------------------
         * INotifyPropertyChanged Methods
         * ------------------------------------------------------------------------------------------------------
         */
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
