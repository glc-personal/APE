namespace APE.Core.Interfaces
{
    public interface IReagent
    {
        int Id { get; set; }
        ILiquidClass LiquidClass { get; set; }
    }
}
