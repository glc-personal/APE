namespace APE.Core.Interfaces
{
    public interface ITransferSolutionProtocolStep : IProtocolStep
    {
        ILiquidClass LiquidClass { get; set; }
        int Volume { get; set; }
        ILocation Origin { get; set; }
        ILocation Destination { get; set; }
    }
}
