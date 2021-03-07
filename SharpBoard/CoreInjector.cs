using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace SharpBoard
{
    public static class CoreInjector
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CoreInjector).Assembly);

            return services;
        }
    }
}
