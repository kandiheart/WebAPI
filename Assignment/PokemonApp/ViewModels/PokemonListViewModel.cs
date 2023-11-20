using PokemonApp.Models;
using PokemonApp.Services;
using PokemonApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokemonApp.ViewModels
{
    public class PokemonListViewModel: BaseViewModel
    {
        private readonly IPokemonService _pokemonService;
        
        public ICommand AddItemCommand { get; }
        public IList<Pokemon> Pokemons { get; set; }

        public PokemonListViewModel(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
            Title = "Pokemon List";
            AddItemCommand = new Command(OnAddItem);
            _ = OnAppearing();
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewPokemonPage));
        }

        public async Task OnAppearing()
        {
            if (Pokemons == null || Pokemons.Count == 0)
            {
                try
                {
                    var list = await _pokemonService.GetPokemonsAsync();

                    if (list != null)
                    {
                        SessionInfo.Instance.Pokemons = list.ToList();
                        Pokemons = SessionInfo.Instance.Pokemons;
                        OnPropertyChanged(nameof(Pokemons));
                    }

                    SessionInfo.Instance.LoggedIn = true;
                }
                catch (Exception ex)
                {
                    // Handle the exception, log it, or show an error message
                    Console.WriteLine($"Error fetching Pokemons: {ex.Message}");
                }
            }
        }
    }
}
