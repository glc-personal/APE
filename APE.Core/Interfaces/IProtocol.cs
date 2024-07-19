using System.Collections.ObjectModel;
using System;

namespace APE.Core.Interfaces
{
    public interface IProtocol
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        IUser Author { get; set; }
        DateTime DateCreatedOn { get; set; }
        ObservableCollection<IProtocolStep> Steps { get; set; } 
        IVersion Version { get; set; }
    }
}
