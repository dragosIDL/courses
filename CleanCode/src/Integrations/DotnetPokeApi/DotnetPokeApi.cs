using Domain.Interfaces;

using PokeApiNet;

using Pokemon = PokeApiNet.Pokemon;

namespace Integrations.DotnetPokeApi;

public class DotnetPokeApi : IPokemonApi
{
    private readonly PokeApiClient _pokeApiClient;

    public DotnetPokeApi(PokeApiClient pokeApiClient)
    {
        _pokeApiClient = pokeApiClient;
    }

    public async Task<List<Domain.Models.Pokemon>> GetAllPokemons()
    {
        var pokemons = await _pokeApiClient.GetNamedResourcePageAsync<Pokemon>();
        return pokemons.Results.Select(p => new Domain.Models.Pokemon()
        {
            Abilities = new List<Domain.Models.Ability>(),
            Id = 0,
            Name = p.Name
        }).ToList();
    }
}
