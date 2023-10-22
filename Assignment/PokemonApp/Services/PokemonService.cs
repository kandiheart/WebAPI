using PokemonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Services
{
    internal class PokemonService : IPokemonService
    {
        // base URL for the pokemon API, use ngrok
        const string BaseUrl = "";

        public async Task<Pokemon> AddPokemonAsync(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public async Task<Pokemon> DeletePokemonAsync(int pokemonId)
        {
            throw new NotImplementedException();
        }

        public async Task<Pokemon> GetPokemonAsync(int pokemonId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Pokemon> UpdatePokemonAsync(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}
