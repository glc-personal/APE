namespace APE.Core.Interfaces
{
    public interface IReagent
    {
        int Id { get; set; }
        string Name { get; set; }
        ILiquidClass LiquidClass { get; set; }
    }
}
