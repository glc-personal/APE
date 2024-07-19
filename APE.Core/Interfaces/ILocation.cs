using APE.Core.Enumerations;

namespace APE.Core.Interfaces
{
    public interface ILocation
    {
        int Id { get; set; }
        ConsumableEnum Consumable { get; set; }
        TrayEnum Tray { get; set; }
        ColumnEnum Column { get; set; }

        string GetName();
    }
}
