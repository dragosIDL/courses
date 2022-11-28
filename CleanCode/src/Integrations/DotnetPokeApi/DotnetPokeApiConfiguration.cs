using Domain.Interfaces;

using Microsoft.Extensions.DependencyInjection;

using PokeApiNet;

namespace Integrations.DotnetPokeApi;

public static class DotnetPokeApiConfiguration
{
    public static IServiceCollection AddDotnetPokeApi(this IServiceCollection services)
    {
        services.AddHttpClient<PokeApiClient>();
        services.AddSingleton<IPokemonApi, DotnetPokeApi>();

        return services;
    }
}
