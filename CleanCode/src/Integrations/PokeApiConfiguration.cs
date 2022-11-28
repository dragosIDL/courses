using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Integrations;

public static class PokeApiConfiguration
{
    public static IServiceCollection AddPokeApi(this IServiceCollection services)
    {
        services.AddHttpClient<IPokemonApi, PokeApi>();
        
        return services;
    }
}
