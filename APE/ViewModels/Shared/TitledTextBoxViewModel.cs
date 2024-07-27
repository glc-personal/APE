namespace APE.ViewModels.Shared
{
    public class TitledTextBoxViewModel : ViewModelBase
    {
        /*
         * --------------------------------------------------------------------------------------------------------
         * Private Attributes
         * --------------------------------------------------------------------------------------------------------
         */
        private string title;
        private string defaultText;
        private string textBoxWidth;

        /*
         * --------------------------------------------------------------------------------------------------------
         * Public Attributes
         * --------------------------------------------------------------------------------------------------------
         */
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string DefaultText
        {
            get => defaultText;
            set
            {
                defaultText = value;
                OnPropertyChanged(nameof(DefaultText));
            }
        }
        public string TextBoxWidth
        {
            get => textBoxWidth;
            set
            {
                textBoxWidth = value;
                OnPropertyChanged(nameof(TextBoxWidth));
            }
        }

        /*
         * --------------------------------------------------------------------------------------------------------
         * 
         * --------------------------------------------------------------------------------------------------------
         */
    }
}
