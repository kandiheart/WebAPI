using CoffeeApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Services
{
    internal class CoffeeService : ICoffeeService
    {
        // base URL for the Coffee API
        const string BaseUrl = "https://8feb-47-12-200-11.ngrok-free.app/";

        public async Task<Coffee> AddCoffeeAsync(Coffee coffee)
        {
            string sCoffee = JsonConvert.SerializeObject(coffee);

            using (var client = new HttpClient(new HttpClientHandler()))
            {
                var content = new StringContent(sCoffee, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{BaseUrl}/api/coffee", content);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Coffee>(json);
                }
                else
                {
                    return new Coffee();
                }
            }
        }

        public async Task<Coffee> DeleteCoffeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Coffee> GetCoffeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Coffee>> GetCoffeesAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{BaseUrl}/api/coffee");
                return JsonConvert.DeserializeObject<IEnumerable<Coffee>>(json);
            }
        }

        public async Task<Coffee> UpdateCoffeeAsync(Coffee coffee)
        {
            throw new NotImplementedException();
        }
    }
}
