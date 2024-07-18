namespace APE.Core.Interfaces
{
    public interface IAddReagentProtocolStep : IProtocolStep
    {
        int ReagentVolume { get; set; }
        IReagent Reagent { get; set; }
        ITip Tip { get; set; }
    }
}
