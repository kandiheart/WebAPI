using CommunityToolkit.Mvvm.ComponentModel;
using PokemonApp.Models;
using PokemonApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.ViewModels
{
    [QueryProperty(nameof(Pokemon), "Pokemon")]
    public partial class PokemonDetailViewModel : BaseViewModel
    {
        private readonly IPokemonService _service;

        [ObservableProperty]
        public Pokemon pokemon;

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public PokemonDetailViewModel(IPokemonService service)
        {
            _service = service;
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
        }

        private async void OnCancel(object obj)
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave(object obj)
        {
            var newPokemon = await UpdatePokemon(Pokemon);
            if (newPokemon != null)
            {
                SessionInfo.Instance.Pokemons.Add(newPokemon);
                //await DisplayAlert("Success", "Pokemon added successfully", "OK");
                await Shell.Current.GoToAsync("//pokemons");
            }
            else
            {
                //await App.Current.MainPage.DisplayAlert("Error", "Pokemon not added", "OK");
                await Shell.Current.GoToAsync("//about");
            }
        }

        private Task<Pokemon> UpdatePokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}
