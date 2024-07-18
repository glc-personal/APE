using APE.Core.Enumerations;
using APE.Core.Interfaces;

namespace APE.Core.Implementations
{
    public class Tip : ITip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RowEnum PipetteRow { get; set; }
        public TrayEnum TipBoxTray { get; set; }
        public ColumnEnum TipBoxColumn { get; set; }
        public RowEnum TipBoxRow { get; set; }
        public bool IsAttached { get; set; }
        public bool IsUsed { get; set; }
        public bool IsEjected { get; set; }
    }
}
