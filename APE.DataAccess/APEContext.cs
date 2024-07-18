using APE.Core.Enumerations;
using APE.Core.Implementations;
using APE.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace APE.DataAccess
{
    public class APEContext : DbContext
    {
        public APEContext(DbContextOptions<APEContext> options) : base(options) { }

        public DbSet<Protocol> Protocols { get; set; }
        //public DbSet<LiquidClass> LiquidClasses { get; set; }
        //public DbSet<Reagent> Reagents { get; set; }
        //public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Protocol>()
                .HasMany(p => p.Steps);

            modelBuilder.Entity<IProtocolStep>()
                .HasDiscriminator<string>("StepType")
                .HasValue<IProtocolStep>("ProtocolStep")
                .HasValue<AddSampleProtocolStep>("AddSampleProtocolStep")
                .HasValue<AddReagentProtocolStep>("AddReagentProtocolStep")
                .HasValue<TransferSolutionProtocolStep>("TransferSolutionProtocolStep");


            // Default Data setup goes here
            /*
            modelBuilder.Entity<Protocol>().HasData(
                new Protocol
                {

                });
            */
        }
    }
}
