using APE.Core.Implementation;
using APE.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace APE.DataAccess
{
    public class APEContext : DbContext
    {
        public APEContext(DbContextOptions<APEContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProtocolEntity> Protocols { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Setup a development user (will be replaced with an Admin user)
            UserEntity user = new UserEntity
            {
                Id = 1,
                Username = "glc-biorad",
                FirstName = "Gabe",
                LastName = "Lopez-Candales",
                Email = "gabriel_lopez-candales@bio-rad.com",
                IsEmailConfirmed = false,
                Phone = "(523)455-9789",
                IsPhoneConfirmed = false,
                DateCreatedOn = System.DateTime.Now,
            };
            modelBuilder.Entity<UserEntity>().HasData(user);

            modelBuilder.Entity<ProtocolEntity>()
                .HasOne(p => p.Author)
                .WithMany()
                .HasForeignKey(p => p.AuthorId);

            // Setup a development protocol (will be replaced with an actual protocol)
            modelBuilder.Entity<ProtocolEntity>().HasData(
                new ProtocolEntity
                {
                    Id = 1,
                    Name = "Integration Protocol",
                    Description = "Protocol for testing system integration.",
                    AuthorId = user.Id,
                    DateCreatedOn = System.DateTime.Now,
                    Version = "1.0.0",
                    MongoDbStepsId = "n3jnj3n899k"
                });
        }
    }
}
