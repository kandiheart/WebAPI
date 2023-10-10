using CoffeeApp.Models;
using CoffeeApp.Services;
using CoffeeApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.ViewModels
{
    internal class ItemsViewModel: BaseViewModel
    {
        private Item _selectedItem;

        private IDataStore<Item> _dataStore;

        public ObservableCollection<Item> Items { get; set; }

        public Command LoadItemsCommand { get; set; }

        public Command AddItemCommand { get; set; }

        public Command<Item> ItemTapped { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<Item>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            _dataStore = new MockDataStore();
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        private async void OnItemSelected(Item item)
        {
            if(item == null)
            {
                return;
            }

            Items.Add(item);
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");

        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await _dataStore.GetItemsAsync(true);
                foreach(var item in items)
                {
                    Items.Add(item);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
