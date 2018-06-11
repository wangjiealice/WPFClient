using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MTBNetClient
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
            services.AddTransient<MTBNetClientViewModel>();
            services.AddSingleton<IMessagingService, MessagingService>();

            Container = services.BuildServiceProvider();
        }

        public IServiceProvider Container { get; private set; }

    }


}
