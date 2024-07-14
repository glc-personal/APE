using System.ComponentModel;

namespace APE.ViewModels.Shared
{
    public class BannerViewModel : INotifyPropertyChanged
    {
        /*
         * --------------------------------------------------------------------------------------------------------
         * Private Attributes
         * --------------------------------------------------------------------------------------------------------
         */
        private string description {  get; set; }
        private string title { get; set; }
        private string iconPath { get; set; }

        /*
         * --------------------------------------------------------------------------------------------------------
         * Public Attributes
         * --------------------------------------------------------------------------------------------------------
         */
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanger(nameof(Description));
            }
        }
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanger(nameof(Title));
            }
        }
        public string IconPath
        {
            get => iconPath;
            set
            {
                iconPath = value;
                OnPropertyChanger(nameof(IconPath));
            }
        }

        /*
         * --------------------------------------------------------------------------------------------------------
         * INotifyPropertyChanged Methods
         * --------------------------------------------------------------------------------------------------------
         */
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanger(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
    }
}
