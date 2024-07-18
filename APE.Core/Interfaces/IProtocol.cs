using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace APE.Core.Interfaces
{
    public interface IProtocol : INotifyPropertyChanged
    {
        int Id { get; set; }
        string Name { get; set; }
        ObservableCollection<IProtocolStep> Steps { get; set; }

        void AddStep(IProtocolStep step, int idx);
        IProtocolStep RemoveStep(int stepId);
    }
}
