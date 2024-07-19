using APE.Core.Enumerations;
using APE.Core.Interfaces;

namespace APE.Core.Implementation
{
    public class Location : ILocation
    {
        public int Id { get; set; }
        public ConsumableEnum Consumable { get; set; }
        public TrayEnum Tray { get; set; }
        public ColumnEnum Column { get; set; }

        public string GetName()
        {
            return "";
        }
    }
}
