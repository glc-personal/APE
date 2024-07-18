using APE.Core.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace APE.Core.Implementations
{
    public class Protocol : IProtocol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private ObservableCollection<IProtocolStep> steps;

        public ObservableCollection<IProtocolStep> Steps
        {
            get => steps;
            set
            {
                steps = value;
                OnPropertyChanged(nameof(Steps));
            }
        }

        public void AddStep(IProtocolStep step, int idx)
        {
            if (idx < 0 || idx > Steps.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(idx), "Index is out of range.");
            }
            Steps.Insert(idx, step);
        }

        public IProtocolStep RemoveStep(int stepId)
        {
            IProtocolStep step = steps.FirstOrDefault(x => x.Id == stepId);
            steps.RemoveAt(stepId);
            return step;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
