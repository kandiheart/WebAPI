using PokemonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Services
{
    public interface IPokemonService
    {
        Task<IEnumerable<Pokemon>> GetPokemonsAsync();
        Task<Pokemon> AddPokemonAsync(Pokemon pokemon);
        Task<Pokemon> UpdatePokemonAsync(Pokemon pokemon);
        Task<Pokemon> DeletePokemonAsync(int pokemonId);
        Task<Pokemon> GetPokemonAsync(int pokemonId);

    }
}
