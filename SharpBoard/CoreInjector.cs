using Microsoft.Extensions.DependencyInjection;
using SharpBoard.Domain.Keyboards;

namespace SharpBoard
{
    public static class CoreInjector
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IKeyboard, TesoroKeyboard>();

            return services;
        }
    }
}
