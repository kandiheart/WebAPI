using CoffeeApp.Models;
using CoffeeApp.Services;
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
