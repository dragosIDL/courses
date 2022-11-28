using System.Text.Json;
using Domain.Interfaces;
using Domain.Models;

namespace Integrations;

public class PokeApi : IPokemonApi
{
    private readonly HttpClient client;

    public PokeApi(HttpClient client)
    {
        this.client = client;
    }

    private record PaginationResponse<T>
    {
        public required int Count { get; init; }
        public required string Next { get; init; }
        public required string Previous { get; init; }
        public required List<T> Results { get; init; }
    }

    private record PokemonResponse
    {
        public required string Name { get; init; }
        public required string Url { get; init; }
    }

    public async Task<List<Pokemon>> GetAllPokemons()
    {
        var baseUrl = "https://pokeapi.co/api/v2/pokemon/";

        var request = new HttpRequestMessage(HttpMethod.Get, new Uri(baseUrl));
        var response = await client.SendAsync(request);

        var str = await response.Content.ReadAsStringAsync();

        var deserialized = JsonSerializer.Deserialize<PaginationResponse<PokemonResponse>>(str, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        });
        return deserialized.Results
            .Select(p => new Pokemon()
            {
                Abilities = new List<Ability>(),
                Id = 0,
                Name = p.Name
            }).ToList();
    }


}
