using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using APE.ViewModels;

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
