using Injecter;
using Injecter.Hosting.Wpf;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Windows;

namespace SharpBoard.Desktop
{
    public partial class App
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .UseWpfLifetime()
                .ConfigureServices(Injector.AddApplication)
                .UseSerilog(Injector.ConfigureLogger)
                .Build();

            CompositionRoot.ServiceProvider = _host.Services;

            _host.Start();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            _host.Dispose();
        }
    }
}
