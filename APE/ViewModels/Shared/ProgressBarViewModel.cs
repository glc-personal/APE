﻿using System.ComponentModel;
using System.Windows;

namespace APE.ViewModels.Shared
{
    public class ProgressBarViewModel : INotifyPropertyChanged
    {
        /*
         * --------------------------------------------------------------------------------------------------------
         * Private Attributes
         * --------------------------------------------------------------------------------------------------------
         */
        private bool isCompleted;
        private CornerRadius cornerRadius;
        private double progressRatio;

        /*
         * --------------------------------------------------------------------------------------------------------
         * Public Attributes
         * --------------------------------------------------------------------------------------------------------
         */
        public static double Radius = 10;
        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }
        public CornerRadius CornerRadius
        {
            get => cornerRadius;
            set
            {
                cornerRadius = value;
                OnPropertyChanged(nameof(CornerRadius));
            }
        }
        public double ProgressRatio
        {
            get => progressRatio;
            set
            {
                progressRatio = value;
                OnPropertyChanged(nameof(ProgressRatio));
            }
        }

        /*
         * --------------------------------------------------------------------------------------------------------
         * INotifyPropertyChanged Methods 
         * --------------------------------------------------------------------------------------------------------
         */
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
