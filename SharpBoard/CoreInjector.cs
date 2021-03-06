using Microsoft.Extensions.DependencyInjection;
using SharpBoard.Domain.Keyboards;

namespace SharpBoard
{
    public static class CoreInjector
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<TesoroKeyboard>();
            services.AddTransient<RedragonKeyboard>();
            services.AddTransient<IKeyboardFactory, KeyboardFactory>();

            return services;
        }
    }
}
