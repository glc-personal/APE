using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace APE.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<APEContext>
    {
        public APEContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<APEContext>();
            optionsBuilder.UseSqlServer("Server=GLC-G15\\SQLEXPRESS;Database=APE;Trusted_Connection=True;TrustServerCertificate=True;");

            return new APEContext(optionsBuilder.Options);
        }
    }
}
