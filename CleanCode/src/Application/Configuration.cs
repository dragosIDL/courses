using Domain.Configure;

using Integrations.HttpPokeApi;
using Integrations.DotnetPokeApi;

using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Configuration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddDomain();

        services.AddHttpPokeApi();
        //services.AddDotnetPokeApi();

        return services;
    }
}