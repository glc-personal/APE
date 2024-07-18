using APE.Core.Enumerations;

namespace APE.Core.Interfaces
{
    public interface ILiquidClass
    {
        string Name { get; set; }
        ViscosityEnum Viscosity { get; set; }
    }
}
