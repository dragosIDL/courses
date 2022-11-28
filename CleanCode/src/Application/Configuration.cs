using Domain.Configure;
using Integrations;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Configuration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddDomain();

        services.AddPokeApi();

        return services;
    }
}