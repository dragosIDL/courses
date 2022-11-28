using Domain.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace Integrations.HttpPokeApi;

public static class HttpPokeApiConfiguration
{
    public static IServiceCollection AddHttpPokeApi(this IServiceCollection services)
    {
        services.AddHttpClient<IPokemonApi, HttpPokeApi>();

        return services;
    }
}
