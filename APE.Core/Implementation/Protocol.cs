using APE.Core.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APE.Core.Implementation
{
    public class Protocol : IProtocol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IUser Author { get; set; }
        public DateTime DateCreatedOn { get; set; }
        public ObservableCollection<IProtocolStep> Steps { get; set; }
        public IVersion Version { get; set; }
    }
}
