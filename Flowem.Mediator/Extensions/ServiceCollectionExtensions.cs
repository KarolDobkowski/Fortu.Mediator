using Microsoft.Extensions.DependencyInjection;

namespace Fortu.Mediator.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
            => services.AddScoped<IMediator, Mediator>();
    }
}
