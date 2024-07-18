namespace APE.Core.Interfaces
{
    public interface ITransferSolutionProtocolStep : IProtocolStep
    {
        int TransferVolume { get; set; }
        int TransferCount { get; set; }
        ILocation LocationFrom { get; set; }
        ILocation LocationTo { get; set; }
    }
}
