using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;
using APE.ViewModels;
using APE.DataAccess;
using APE.DataAccess.Interfaces;
using APE.DataAccess.Repositories;

namespace APE
{
    public partial class App : Application
    {
        private IServiceProvider serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Setup the Database connection, repositories, etc.
            services.AddDbContext<APEContext>(options =>
                options.UseSqlServer("Server=GLC-G15\\SQLEXPRESS;Database=APE;Trusted_Connection=True;TrustServerCertificate=True;"));
            services.AddScoped<IUserRepository, UserRepository>();

            // Register your view models, etc.
            services.AddTransient<MainWindow>();
            services.AddTransient<MainWindowViewModel>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
