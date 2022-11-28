namespace Domain.Queries;

public record GetFirst10PokemonsCommand : IRequest<List<string>> { }

public class GetFirst10PokemonsHandler : IRequestHandler<GetFirst10PokemonsCommand, List<string>>
{
    private readonly IPokemonApi pokemonApi;

    public GetFirst10PokemonsHandler(IPokemonApi pokemonApi)
    {
        this.pokemonApi = pokemonApi;
    }

    public async Task<List<string>> Handle(GetFirst10PokemonsCommand request, CancellationToken cancellationToken)
    {
        var pokemons = await pokemonApi.GetAllPokemons();
        return pokemons.Take(10).Select(p => p.Name).ToList();
    }
}