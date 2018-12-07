using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Flowem.Mediator.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
            => services.AddScoped<IMediator, Mediator>();
    }
}
