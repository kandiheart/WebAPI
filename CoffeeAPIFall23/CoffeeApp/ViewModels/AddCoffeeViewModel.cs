using CoffeeApp.Models;
using CoffeeApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.ViewModels
{
    internal class AddCoffeeViewModel : AddBeverageViewModel<Coffee>
    {
        private ICoffeeService _coffeeService;

        public Coffee coffee => Model as Coffee;

        public string Name { get => coffee.Name; set => coffee.Name = value; }
        public string Characteristic { get => coffee.Characteristic; set => coffee.Characteristic = value; }
        public string Strength { get => coffee.Strength; set => coffee.Strength = value; }
        public double Cost { get => coffee.Cost; set => coffee.Cost = value; }
        public string ImageURL { get => coffee.ImageURL; set => coffee.ImageURL = value; }

        public Command SaveCommand {get; }

        public Command CancelCommand { get; }

        public AddCoffeeViewModel(ICoffeeService coffeeService) : base(new Coffee())
        {
            _coffeeService = coffeeService;
            AddAction = "Add Coffee";
            SaveCommand = new Command(SaveCoffee);
            CancelCommand = new Command(CancelCoffee);
        }

        private async void CancelCoffee()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void SaveCoffee(object obj)
        {
            var newCoffee = await AddBeverage(coffee);
            if (newCoffee != null)
            {
                //SessionInfo.Instance.Coffees.Add(newCoffee);
                await App.Current.MainPage.DisplayAlert("Success", "Coffee added successfully", "OK");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Coffee not added", "OK");
            }
        }

        public override async Task<Coffee> AddBeverage(Coffee obj)
        {
            obj.Id = Guid.NewGuid();
            return await _coffeeService.AddCoffeeAsync(obj);
        }
    }
}
