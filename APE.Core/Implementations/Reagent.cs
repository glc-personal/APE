using APE.Core.Interfaces;

namespace APE.Core.Implementations
{
    public class Reagent : IReagent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ILiquidClass LiquidClass { get; set; }
    }
}
