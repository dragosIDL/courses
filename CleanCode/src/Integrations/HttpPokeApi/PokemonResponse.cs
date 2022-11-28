namespace Integrations.HttpPokeApi;

internal record PokemonResponse
{
    public required string Name { get; init; }
    public required string Url { get; init; }
}
