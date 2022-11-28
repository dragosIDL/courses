using System.Text.Json;

using Domain.Interfaces;
using Domain.Models;

namespace Integrations.HttpPokeApi;

public class HttpPokeApi : IPokemonApi
{
    private static readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly HttpClient _client;
    
    public HttpPokeApi(HttpClient client) => _client = client;

    public async Task<List<Pokemon>> GetAllPokemons()
    {
        var baseUrl = "https://pokeapi.co/api/v2/pokemon/";

        using var request = new HttpRequestMessage(HttpMethod.Get, new Uri(baseUrl));
        using var response = await _client.SendAsync(request);
        if (response.Content is null)
        {
            return new List<Pokemon>();
        }

        using var stream = await response.Content.ReadAsStreamAsync();
        var deserialized = JsonSerializer.Deserialize<PaginationResponse<PokemonResponse>>(stream, serializerOptions);

        return FromPaginationResponse(deserialized);
    }

    private static List<Pokemon> FromPaginationResponse(PaginationResponse<PokemonResponse>? resp)
    {
        return resp is null
            ? new List<Pokemon>()
            : resp.Results.Select(ToPokemon).ToList();

        static Pokemon ToPokemon(PokemonResponse pokemonResponse) => new()
        {
            Abilities = new List<Ability>(),
            Id = 0,
            Name = pokemonResponse.Name
        };
    }
}