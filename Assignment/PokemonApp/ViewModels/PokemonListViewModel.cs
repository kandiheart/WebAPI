using CommunityToolkit.Mvvm.ComponentModel;
using PokemonApp.Models;
using PokemonApp.Services;
using PokemonApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokemonApp.ViewModels
{
    public partial class PokemonListViewModel : BaseViewModel
    {
        private readonly IPokemonService _pokemonService;

        [ObservableProperty]
        bool isRefreshing;

        public ICommand AddItemCommand { get; }

        public Command GetPokemonsCommand { get; }

        public Command DeletePokemonCommand { get; }

        public ObservableCollection<Pokemon> Pokemons { get; set; } = new ();

        public PokemonListViewModel(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
            Title = "Pokemon List";
            AddItemCommand = new Command(OnAddItem);
            GetPokemonsCommand = new Command(async () => await LoadPokemons());
            DeletePokemonCommand = new Command<Pokemon>(OnDeletePokemon);
            LoadPokemons().ConfigureAwait(false);
        }

        private async void OnDeletePokemon(Pokemon pokemon)
        {
            try
            {
                var deleted = await _pokemonService.DeletePokemonAsync(pokemon.Id);
                Pokemons.Remove(pokemon);
                await LoadPokemons();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to delete pokemon: {ex.Message}");
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync("//newpokemon");
        }

        public async Task LoadPokemons()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var pokemons = await _pokemonService.GetPokemonsAsync();

                if (Pokemons.Count > 0)
                    Pokemons.Clear();

                foreach (var pokemon in pokemons.OrderBy(p => p.Name))
                {
                    Pokemons.Add(pokemon);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get pokemon: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
            
        }
    }
}
