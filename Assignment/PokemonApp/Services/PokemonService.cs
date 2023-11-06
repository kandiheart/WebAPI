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
        const string BaseUrl = "https://adb2-47-12-200-11.ngrok-free.app";

        // Add Pokemon
        // Post
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

        // Delete Pokemon
        // Delete
        public async Task<Pokemon> DeletePokemonAsync(int pokemonId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(BaseUrl + "api/pokemon/" + pokemonId);
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

        // Get Pokemon
        // Get
        public async Task<Pokemon> GetPokemonAsync(int pokemonId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(BaseUrl + "api/pokemon/" + pokemonId);
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

        // Get Pokemons
        // Get
        public async Task<IEnumerable<Pokemon>> GetPokemonsAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(BaseUrl + "api/pokemon");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Pokemon>>(content);
                }
                else
                {
                    return new List<Pokemon>();
                }
            }
        }

        // Update Pokemon
        // Put
        public async Task<Pokemon> UpdatePokemonAsync(Pokemon pokemon)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PutAsync(BaseUrl + "api/pokemon", new StringContent(JsonConvert.SerializeObject(pokemon), Encoding.UTF8, "application/json"));
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
    }
}
