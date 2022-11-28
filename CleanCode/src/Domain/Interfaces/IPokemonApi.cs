using Domain.Models;

namespace Domain.Interfaces;

public interface IPokemonApi
{
    Task<List<Pokemon>> GetAllPokemons();
}