namespace APE.Core.Interfaces
{
    public interface IAddReagentProtocolStep : IProtocolStep
    {
        IReagent Reagent { get; set; }
        int Volume { get; set; }
        ILocation Destination { get; set; }
    }
}
