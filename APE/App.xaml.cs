using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using APE.ViewModels;
using System.Configuration;
using APE.ApplicationServices.Interfaces;
using APE.ApplicationServices.Implementations;

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
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            IServiceConfiguration serviceConfiguration = new ServiceConfiguration();
            serviceConfiguration.ConfigureServices(services, connectionString);

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
