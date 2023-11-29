using PokemonApp.Models;
using PokemonApp.Services;
using PokemonApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public IEnumerable<Pokemon> Pokemons { get; set; }

        public PokemonListViewModel(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
            Title = "Pokemon List";
            AddItemCommand = new Command(OnAddItem);
            Pokemons = SessionInfo.Instance.Pokemons;
            //OnAppearing();
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync("//newpokemon");
        }

        public async void OnAppearing()
        {
            if (Pokemons == null)
            {
                try
                {
                    var list = await _pokemonService.GetPokemonsAsync();

                    if (list != null)
                    {
                        SessionInfo.Instance.Pokemons = list.ToList();
                        Pokemons = new ObservableCollection<Pokemon>(list);
                        //OnPropertyChanged(nameof(Pokemons));
                    }

                    SessionInfo.Instance.LoggedIn = true;

                    await Shell.Current.GoToAsync("//pokemons");
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
