using Newtonsoft.Json;
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
            string sPokemon = JsonConvert.SerializeObject(pokemon);

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(BaseUrl + "api/pokemon", new StringContent(sPokemon, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Pokemon>(content);
                }
                else
                {
                    return new Pokemon();
                }
            }
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
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(BaseUrl + "api/pokemon");
                return JsonConvert.DeserializeObject<IEnumerable<Pokemon>>(content);
            }
        }

        public async Task<Pokemon> UpdatePokemonAsync(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}
