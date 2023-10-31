using CoffeeApp.Models;
using CoffeeApp.Services;
using CoffeeApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoffeeApp.ViewModels
{
    internal class LoginPageViewModel: BasePageViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool LoggedIn => SessionInfo.Instance.LoggedIn;

        public ICommand LoginCommand { get; set; }
        public ICommand CoffeeCommand { get; set; }

        private ICoffeeService _coffeeService;

        public LoginPageViewModel(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
            Username = GetUserName().Result;
            LoginCommand = new Command(async () => 
            { 
                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Username and Password are required", "OK");
                    return;
                }

                try
                {
                    var result = await _coffeeService.GetCoffeesAsync();
                    if (result != null)
                    {
                        SessionInfo.Instance.Coffees = result.ToList();

                        SessionInfo.Instance.LoggedIn = true;
                        await SecureStorage.SetAsync("username", Username);
                        OnPropertyChanged(nameof(LoggedIn));
                        await Application.Current.MainPage.DisplayAlert("Success", "You are now logged in", "OK");
                        await Shell.Current.GoToAsync($"//{nameof(CoffeeListPage)}");

                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Login failed", "OK");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Exception on login: {ex.Message}");
                    await Application.Current.MainPage.DisplayAlert("Error", "Unable to connect", "OK");
                }
            });

            CoffeeCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync($"{nameof(CoffeeListPage)}");
            });
        }

        private static Task<string> GetUserName()
        {
            try
            {
                var nameTask = SecureStorage.GetAsync("username");
                if (string.IsNullOrEmpty(nameTask.Result))
                {
                    return Task.FromResult(string.Empty);
                }
                else
                {
                    return nameTask;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception on getusername: {ex.Message}");
                return Task.FromResult("Exception on getusername");
            }
        }
    }
}
