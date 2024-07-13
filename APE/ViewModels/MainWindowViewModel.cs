using System;
using System.ComponentModel;
using System.Timers;

namespace APE.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        /*
         * ----------------------------------------------------------------------------------------------------------------
         * Status Bar Variables
         * ----------------------------------------------------------------------------------------------------------------
         */
        private string status;
        private string currentTime;
        private string currentDate;
        private Timer timer;

        /*
         * ----------------------------------------------------------------------------------------------------------------
         * Constructor
         * ----------------------------------------------------------------------------------------------------------------
         */
        public MainWindowViewModel()
        {
            // Setup the timer
            timer = new Timer(1000); // Update every 1 second
            timer.Elapsed += TimerElapsed;
            timer.Start();

            // Setup the Status Bar
            status = "Ready";
            currentTime = DateTime.Now.ToString("hh:mm tt");
            currentDate = DateTime.Now.ToString("M/d/yyyy");
        }

        /*
         * ----------------------------------------------------------------------------------------------------------------
         * Properties
         * ----------------------------------------------------------------------------------------------------------------
         */
        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        public string CurrentTime
        {
            get => currentTime;
            set
            {
                currentTime = value;
                OnPropertyChanged(nameof(CurrentTime));
            }
        }
        public string CurrentDate
        {
            get => currentDate;
            set
            {
                currentDate = value;
                OnPropertyChanged(nameof(CurrentDate));
            }
        }

        /*
         * ----------------------------------------------------------------------------------------------------------------
         * Status Bar Private Methods
         * ----------------------------------------------------------------------------------------------------------------
         */
        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("hh:mm tt");
            CurrentDate = DateTime.Now.ToString("M/d/yyyy");
        }

        /*
         * ----------------------------------------------------------------------------------------------------------------
         * INotifyPropertyChanged Members
         * ----------------------------------------------------------------------------------------------------------------
         */
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
