using APE.ApplicationServices.Interfaces;
using APE.DataAccess;
using APE.DataAccess.Interfaces;
using APE.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;

namespace APE.ApplicationServices.Implementations
{
    public class ServiceConfiguration : IServiceConfiguration
    {
        public void ConfigureServices(IServiceCollection services, string connectionString)
        {
            // Register the database context
            services.AddDbContext<APEContext>(options =>
                options.UseSqlServer(connectionString));

            // Register repositories
            services.AddScoped<IUserRepository, UserRepository>();

            // Register application services

            // Register the event aggregator
            services.AddSingleton<IEventAggregator, EventAggregator>();

        }
    }
}
