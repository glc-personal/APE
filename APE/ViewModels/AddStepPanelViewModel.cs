using APE.Commands;
using APE.ViewModels.Shared;
using System.Windows.Input;
using Prism.Events;
using APE.UIEvents;

namespace APE.ViewModels
{
    public class AddStepPanelViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;
        /*
         * ------------------------------------------------------------------------------------------------------
         * Private Attributes
         * ------------------------------------------------------------------------------------------------------
         */
        private ICommand addSampleCommand { get; set; }
        private ICommand addReagentCommand { get; set; }

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
            _eventAggregator.GetEvent<ToggleAddSampleStepContentEvent>().Publish();
        }
        private bool CanExecuteAddSampleCommand(object parameter)
        {
            return true;
        }
        public ICommand AddReagentCommand
        {
            get
            {
                if (addReagentCommand == null)
                {
                    addReagentCommand = new RelayCommand(ExecuteAddReagentCommand, CanExecuteAddReagentCommand);
                }
                return addReagentCommand;
            }
        }
        private void ExecuteAddReagentCommand(object parameter)
        {
            _eventAggregator.GetEvent<ToggleAddReagentStepContentEvent>().Publish();
        }
        private bool CanExecuteAddReagentCommand(object parameter)
        {
            return true;
        }

        /*
         * --------------------------------------------------------------------------------------------------------
         * Constructor
         * --------------------------------------------------------------------------------------------------------
         */
        public AddStepPanelViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
    }

}
