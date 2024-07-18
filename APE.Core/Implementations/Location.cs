using APE.Core.Enumerations;
using APE.Core.Interfaces;

namespace APE.Core.Implementations
{
    public class Location : ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TrayEnum Tray { get; set; }
        public ColumnEnum Column { get; set; }
    }
}
