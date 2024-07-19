using APE.Core.Interfaces;
using System;

namespace APE.Core.Implementation
{
    public class LiquidClass : ILiquidClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreatedOn { get; set; }
        public IUser Author { get; set; }
        public IViscosity Viscosity { get; set; }
        public bool IsArchived { get; set; }
        public bool IsActive { get; set; }
    }
}
