using APE.Core.Enumerations;
using APE.Core.Interfaces;

namespace APE.Core.Implementations
{
    public class AddReagentProtocolStep : ProtocolStepBase, IAddReagentProtocolStep
    {
        public int ReagentVolume { get; set; }
        public IReagent Reagent { get; set; }
        public ITip Tip { get; set; }
    }
}
