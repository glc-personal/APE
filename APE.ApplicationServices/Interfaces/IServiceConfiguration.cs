using Microsoft.Extensions.DependencyInjection;

namespace APE.ApplicationServices.Interfaces
{
    public interface IServiceConfiguration
    {
        void ConfigureServices(IServiceCollection services, string connectionString);
    }
}
