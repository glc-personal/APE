using APE.Core.Enumerations;
using APE.Core.Interfaces;

namespace APE.Core.Implementations
{
    public class AddSampleProtocolStep : ProtocolStepBase, IAddSampleProtocolStep
    {
        public int SampleVolume { get; set; }
        public ITip Tip { get; set; }
    }
}
