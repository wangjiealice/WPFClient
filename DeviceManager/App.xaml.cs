using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<DeviceManagerViewModel>();

            Container = services.BuildServiceProvider();
        }

        public IServiceProvider Container { get; private set; }
    }
}
