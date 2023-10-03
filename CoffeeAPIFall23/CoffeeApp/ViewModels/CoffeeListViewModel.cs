using CoffeeApp.Models;
using CoffeeApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoffeeApp.ViewModels
{
    internal class CoffeeListViewModel : BaseViewModel
    {
        private ICoffeeService _coffeeService;
        public ICommand AddItemCommand { get; }

        public List<Coffee> Coffees => SessionInfo.Instance.Coffees?.ToList();
        public CoffeeListViewModel() : base(null)
        {
            Title = "Coffee List";
        }

        public CoffeeListViewModel(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
            Title = "Coffee List";
            AddItemCommand = new Command(OnAddItem);
        }

        private async void OnAddItem(object obj)
        {
            // add view for newcoffeepage
            //await Shell.Current.GoToAsync(nameof(NewCoffeePage));
        }

        public async Task OnAppearing()
        {
            if (Coffees == null || Coffees.Count == 0)
            {
                var coffees = await _coffeeService.GetCoffeesAsync();
                SessionInfo.Instance.Coffees = coffees.ToList();
                OnPropertyChanged(nameof(coffees));
            }
        }
    }
}
