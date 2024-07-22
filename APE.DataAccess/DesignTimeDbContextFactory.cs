using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace APE.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<APEContext>
    {
        public APEContext CreateDbContext(string[] args)
        {
             
            var optionsBuilder = new DbContextOptionsBuilder<APEContext>();

            // Obtain the connection string to the database
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);

            return new APEContext(optionsBuilder.Options);
        }
    }
}
