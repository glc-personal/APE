using APE.Commands;
using APE.ViewModels.Shared;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace APE.ViewModels
{
    public class AddStepPanelViewModel : INotifyPropertyChanged
    {
        /*
         * ------------------------------------------------------------------------------------------------------
         * Private Attributes
         * ------------------------------------------------------------------------------------------------------
         */
        private ICommand addSampleCommand { get; set; }

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
        public ICommand AddSampleCommand
        {
            get
            {
                if (addSampleCommand == null)
                {
                    addSampleCommand = new RelayCommand(ExecuteAddSampleCommand, CanExecuteAddSampleCommand);
                }
                return addSampleCommand;
            }
        }
        private void ExecuteAddSampleCommand(object parameter)
        {
            MessageBox.Show("Add Sample");
        }
        private bool CanExecuteAddSampleCommand(object parameter)
        {
            return true;
        }


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
