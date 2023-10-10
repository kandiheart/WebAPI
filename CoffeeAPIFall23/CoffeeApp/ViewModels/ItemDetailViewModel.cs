using CoffeeApp.Models;
using CoffeeApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.ViewModels
{
    internal class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;

        private IDataStore<Item> _dataStore;

        public ItemDetailViewModel()
        {
            _dataStore = new MockDataStore();
        }

        public string Id
        {
            get => itemId;
            set => SetProperty(ref itemId, value);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId 
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        private async void LoadItemId(string value)
        {
            try
            {
                var item = await _dataStore.GetItemAsync(value);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
                throw;
            }
        }
    }
}
