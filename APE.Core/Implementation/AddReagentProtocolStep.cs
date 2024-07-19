using APE.Core.Interfaces;

namespace APE.Core.Implementation
{
    public class AddReagentProtocolStep : ProtocolStepBase, IAddReagentProtocolStep
    {
        public IReagent Reagent { get; set; }
        public int Volume { get; set; }
        public ILocation Destination { get; set; }
    }
}
