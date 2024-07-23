namespace APE.ViewModels.StepContent
{
    public class AddSampleStepContentViewModel : ViewModelBase
    {
        public StepContentViewModel MyStepContentViewModel { get; set; }

        private string batch;
        private string sampleType;
        private int volume;
        private bool requiresNewTips;

        public string Batch
        {
            get => batch;
            set
            {
                batch = value;
                OnPropertyChanged(nameof(batch));
            }
        }
        public string SampleType
        {
            get => sampleType;
            set
            {
                sampleType = value;
                OnPropertyChanged(nameof(sampleType));
            }
        }
        public int Volume
        {
            get => volume;
            set
            {
                volume = value;
                OnPropertyChanged(nameof(volume));
            }
        }
        public bool RequiresNewTips
        {
            get => requiresNewTips;
            set
            {
                requiresNewTips = value;
                OnPropertyChanged(nameof(requiresNewTips));
            }
        }
    }
}
