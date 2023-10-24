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
    internal class PokemonListViewModel: BaseViewModel
    {
        private readonly IPokemonService _pokemonService;
        
        public ICommand AddItemCommand { get; }
        public List<Pokemon> Pokemons => SessionInfo.Instance.Pokemons?.ToList();

        public PokemonListViewModel(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
            Title = "Pokemon List";
            AddItemCommand = new Command(OnAddItem);
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewPokemonPage));
        }

        public async Task OnAppearing() 
        {
            if (Pokemons == null || Pokemons.Count == 0)
            {
                var pokemons = await _pokemonService.GetPokemonsAsync();
                SessionInfo.Instance.Pokemons = pokemons.ToList();
                OnPropertyChanged(nameof(Pokemons));
            }
        }
    }
}
