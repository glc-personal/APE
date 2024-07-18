using APE.Core.Interfaces;

namespace APE.Core.Implementations
{
    public class TransferSolutionProtocolStep : ProtocolStepBase, ITransferSolutionProtocolStep
    {
        public int TransferVolume { get; set; }
        public int TransferCount { get; set; }
        public ILocation LocationFrom { get; set; }
        public ILocation LocationTo { get; set; }
    }
}
