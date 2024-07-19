using APE.Core.Interfaces;

namespace APE.Core.Implementation
{
    public class TransferSolutionProtocolStep : ProtocolStepBase, ITransferSolutionProtocolStep
    {
        public ILiquidClass LiquidClass { get; set; }
        public int Volume { get; set; }
        public ILocation Origin { get; set; }
        public ILocation Destination { get; set; }
    }
}
