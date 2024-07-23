namespace APE.ViewModels.StepContent
{
    class AddReagentStepContentViewModel : ViewModelBase
    {
        public StepContentViewModel MyStepContentViewModel { get; set; }

        /* 
         * -------------------------------------------------------------------------------------------------------
         * Private Attributes
         * -------------------------------------------------------------------------------------------------------
         */
        private string batch;
        private string reagent;
        private int volume;
        private string destination;
        private bool requiresNewTips;

        /* 
         * -------------------------------------------------------------------------------------------------------
         * Public Attributes
         * -------------------------------------------------------------------------------------------------------
         */
        public string Batch
        {
            get => batch;
            set
            {
                batch = value;
                OnPropertyChanged(nameof(Batch));
            }
        }
        private string Reagent
        {
            get => reagent;
            set
            {
                reagent = value;
                OnPropertyChanged(nameof(Reagent));
            }
        }
        private int Volume
        {
            get => volume;
            set
            {
                volume = value;
                OnPropertyChanged(nameof(Volume));
            }
        }
        private string Destination
        {
            get => destination;
            set
            {
                destination = value;
                OnPropertyChanged(nameof(Destination));
            }
        }
    }
}
