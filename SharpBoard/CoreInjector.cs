using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MoreLinq;
using SharpBoard.Domain.Keyboards;
using System.Linq;

namespace SharpBoard
{
    public static class CoreInjector
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CoreInjector).Assembly);

            services.AddTransient<IKeyboardFactory, KeyboardFactory>();
            services.AddKeyboards();

            return services;
        }

        private static IServiceCollection AddKeyboards(this IServiceCollection services)
        {
            typeof(CoreInjector).Assembly
                .GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface && typeof(IKeyBoard).IsAssignableFrom(t))
                .Select(t => new ServiceDescriptor(t, t, ServiceLifetime.Transient))
                .ForEach(services.Add);

            return services;
        }
    }
}
