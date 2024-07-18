using APE.Core.Implementation;
using Microsoft.EntityFrameworkCore;
using System;

namespace APE.DataAccess
{
    public class APEContext : DbContext
    {
        public APEContext(DbContextOptions<APEContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure user 
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
            });

            // Setup a development user (will be replaced with an Admin user)
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "glc-biorad",
                    FirstName = "Gabe",
                    LastName = "Lopez-Candales",
                    Email = "gabriel_lopez-candales@bio-rad.com",
                    IsEmailConfirmed = false,
                    Phone = "(523)455-9789",
                    IsPhoneConfirmed = false,
                    DateCreatedOn = DateTime.Now,
                });

        }
    }
}
