using APE.Core.Enumerations;

namespace APE.Core.Interfaces
{
    public interface ITip
    {
        int Id { get; set; }
        string Name { get; set; }
        RowEnum PipetteRow { get; set; }
        TrayEnum TipBoxTray { get; set; }
        ColumnEnum TipBoxColumn { get; set; }
        RowEnum TipBoxRow { get; set; }
        bool IsAttached { get; set; }
        bool IsUsed { get; set; }
        bool IsEjected { get; set; }
    }
}
