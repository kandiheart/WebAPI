using Newtonsoft.Json;
using PokemonApp.Models;
using PokemonApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Services
{
    public class PokemonService : IPokemonService
    {
        private HttpClient _client = new HttpClient();
        private readonly AppSettings _settings;
        private readonly string BaseUrl;

        public PokemonService(AppSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            BaseUrl = _settings.APIURL;
        }

        // Add Pokemon
        // Post
        public async Task<Pokemon> AddPokemonAsync(Pokemon pokemon)
        {
            string sPokemon = JsonConvert.SerializeObject(pokemon);

            using (_client)
            {
                var response = await _client.PostAsync(BaseUrl + "/api/Pokemon", new StringContent(sPokemon, Encoding.UTF8, "application/json"));
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
            using (_client)
            {
                var response = await _client.DeleteAsync(BaseUrl + "/api/Pokemon/" + pokemonId);
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
            using (_client)
            {
                var response = await _client.GetAsync(BaseUrl + "/api/Pokemon/" + pokemonId);
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
            using (_client)
            {
                try
                {
                    string apiUrl = "/api/Pokemon";
                    var response = await _client.GetAsync(BaseUrl + apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        IEnumerable<Pokemon> pokemons = JsonConvert.DeserializeObject<Pokemon[]>(content);
                        return pokemons;
                    }
                    else
                    {
                        return new List<Pokemon>();
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"HTTP request failed: {ex.Message}");
                    return new List<Pokemon>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return new List<Pokemon>();
                }
            }
        }

        // Update Pokemon
        // Put
        public async Task<Pokemon> UpdatePokemonAsync(Pokemon pokemon)
        {
            using (_client)
            {
                var response = await _client.PutAsync(BaseUrl + "/api/Pokemon", new StringContent(JsonConvert.SerializeObject(pokemon), Encoding.UTF8, "application/json"));
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
