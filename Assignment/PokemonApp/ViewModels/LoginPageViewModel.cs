using Android.Content.Res;
using AndroidX.Navigation;
using PokemonApp.Models;
using PokemonApp.Services;
using PokemonApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokemonApp.ViewModels
{
    public class LoginPageViewModel: BasePageViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool LoggedIn => SessionInfo.Instance.LoggedIn;

        public ICommand LoginCommand { get; set; }
        public ICommand PokemonCommand { get; set; }
        private readonly IPokemonService _pokemonService;

        public LoginPageViewModel(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
            LoginCommand = new Command(async () =>
            {
                /*if (string.IsNullOrEmpty(Password) || Password.Length < 5)
                {
                    //await Page.DisplayAlert("Logn Failure", "Login Failed, please enter a valid password", "Ok");
                    return;
                }*/

                try
                {
                    await SecureStorage.SetAsync("UserName", Username);

                    var list = await _pokemonService.GetPokemonsAsync();
                    if (list != null)
                        SessionInfo.Instance.Pokemons = list.ToList();

                    SessionInfo.Instance.LoggedIn = true;
                    //OnPropertyChanged(nameof(LoggedIn));

                    // await Shell.Current.GoToAsync(nameof(PokemonsPage));
                    await Shell.Current.GoToAsync("//pokemons");
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                    // await MainPage.DisplayAlert("Logn Failure", "Login Failed, please enter a valid password", "Ok");
                }
            });

            //Username = GetUserName().Result;
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
