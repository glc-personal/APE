using APE.Core.Interfaces;

namespace APE.Core.Implementation
{
    public class AddSampleProtocolStep : ProtocolStepBase, IAddSampleProtocolStep
    {
        public ISample Sample { get; set; }
        public int Volume { get; set; }
        public ILocation Destination { get; set; }
    }
}
