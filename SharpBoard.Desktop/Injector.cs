using Injecter;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using TesoroRgb.Core;

namespace SharpBoard.Desktop
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Redundancy", "RCS1163:Unused parameter.", Justification = "False Positive")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "False Positive")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "False Positive")]
    public static class Injector
    {
        public static void AddApplication(HostBuilderContext hostBuilder, IServiceCollection services)
        {
            services.AddCore();

            services.AddInjecter(o => o.UseCaching = true);

            services.AddMediatR(typeof(CoreInjector).Assembly);

            services.AddSingleton<Keyboard>();
        }

        public static void ConfigureLogger(HostBuilderContext hostBuilder, IServiceProvider serviceProvider, LoggerConfiguration loggerConfiguration) =>
            loggerConfiguration.WriteTo.Debug();
    }
}
