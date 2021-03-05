using Injecter;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using TesoroRgb.Core;

namespace SharpBoard.Desktop
{
    public static class Injector
    {
        public static void AddApplication(HostBuilderContext hostBuilder, IServiceCollection services)
        {
            services.AddInjecter(o => o.UseCaching = true);

            services.AddMediatR(typeof(Injector).Assembly);

            services.AddSingleton<Keyboard>();
        }

        public static void ConfigureLogger(HostBuilderContext hostBuilder, IServiceProvider serviceProvider, LoggerConfiguration loggerConfiguration) =>
            loggerConfiguration.WriteTo.Debug();
    }
}
