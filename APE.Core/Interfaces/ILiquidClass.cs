using System;

namespace APE.Core.Interfaces
{
    public interface ILiquidClass
    {
        int Id { get; set; }
        string Name { get; set; }
        IUser Author { get; set; }
        DateTime DateCreatedOn { get; set; }
        bool IsArchived { get; set; }
        bool IsActive { get; set; }
        IViscosity Viscosity { get; set; }
    }
}
