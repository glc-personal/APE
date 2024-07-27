using APE.ViewModels.Shared;

namespace APE.ViewModels.StepContent
{
    public class StepContentViewModel : ViewModelBase
    {

        /*
         * ------------------------------------------------------------------------------------------------------
         * User Controls
         * ------------------------------------------------------------------------------------------------------
         */
        public BannerViewModel MyBannerViewModel { get; set; }
        public DescriptorViewModel MyDescriptorViewModel { get; set; }
        public TitledTextBoxViewModel MyBatchTitledTextBoxViewModel { get; set; }
        public TitledTextBoxViewModel MyVolumeTitleTextBoxViewModel { get; set; }

        /*
         * ------------------------------------------------------------------------------------------------------
         * Private Attributes
         * ------------------------------------------------------------------------------------------------------
         */
        private string stepName;
        private string batch;
        private string sampleType;
        private int volume;
        private bool requiresNewTips;

        /*
         * ------------------------------------------------------------------------------------------------------
         * Public Attributes
         * ------------------------------------------------------------------------------------------------------
         */
        public string StepName
        {
            get => stepName;
            set
            {
                stepName = value;
                OnPropertyChanged(nameof(StepName));
            }
        }
        public string Batch
        {
            get => batch;
            set
            {
                batch = value;
                OnPropertyChanged(nameof(Batch));
            }
        }
        public string SampleType
        {
            get => sampleType;
            set
            {
                sampleType = value;
                OnPropertyChanged(nameof(SampleType));
            }
        }
        public int Volume
        {
            get => volume;
            set
            {
                volume = value;
                OnPropertyChanged(nameof(Volume));
            }
        }
        public bool RequiresNewTips
        {
            get => requiresNewTips;
            set
            {
                requiresNewTips = value;
                OnPropertyChanged(nameof(RequiresNewTips));
            }
        }
    }
}
