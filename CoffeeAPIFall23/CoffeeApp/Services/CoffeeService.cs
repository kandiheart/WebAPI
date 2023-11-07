using CoffeeApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Services
{
    internal class CoffeeService : ICoffeeService
    {
        // ngrok is being a pain
        // TODO: find another way to access the api or database

        /*private HttpClient client;

        // base URL for the Coffee API, changes everytime ngrok is started in docker
        const string BaseUrl = "https://7a3c-47-12-200-11.ngrok-free.app/";

        public CoffeeService() 
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }*/
              

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
            

            /*try
            {
                string apiURL = "api/coffee";
                HttpResponseMessage response = await client.GetAsync($"{BaseUrl}{apiURL}");
                // returns 502 Bad Gateway
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Coffee>>(json);
                }
                else
                {
                    return new List<Coffee>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Coffee>();
            }*/
        }

        public async Task<Coffee> UpdateCoffeeAsync(Coffee coffee)
        {
            throw new NotImplementedException();
        }
    }
}
