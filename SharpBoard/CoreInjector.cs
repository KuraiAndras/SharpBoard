using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SharpBoard.Domain.Keyboards;

namespace SharpBoard
{
    public static class CoreInjector
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.TryAddTransient<TesoroKeyboard>();
            services.TryAddTransient<RedragonKeyboard>();
            services.TryAddTransient<IKeyboardFactory, KeyboardFactory>();

            services.AddMediatR(typeof(CoreInjector).Assembly);

            return services;
        }
    }
}
