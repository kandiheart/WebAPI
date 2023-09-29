using CoffeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Services
{
    internal class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Graphics Card", Description="NVIDIA GeForce RTX 3080 for high-end gaming." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "SSD", Description="Samsung 970 EVO 1TB NVMe M.2 Internal SSD for faster data storage." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "RAM", Description="Corsair Vengeance 32GB DDR4 3200MHz for smooth multitasking." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Motherboard", Description="ASUS ROG Strix Z490-E Gaming Motherboard with Wi-Fi 6." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "CPU", Description="AMD Ryzen 9 5950X 16-core, 32-thread processor for heavy workloads." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Cooling System", Description="Noctua NH-D15, Dual Tower CPU Cooler for efficient heat dissipation." }
            };
        }
        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);
            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            var result = items.FirstOrDefault(s => s.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);
            return await Task.FromResult(true);
        }
    }
}
