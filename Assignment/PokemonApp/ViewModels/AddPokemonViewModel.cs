using PokemonApp.Models;
using PokemonApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.ViewModels
{
    internal class AddPokemonViewModel
    {
        protected object Model;
        public string AddAction { get; set; }
        private IPokemonService _pokemonService;

        public Pokemon pokemon => Model as Pokemon;

        public string Name { get => pokemon.Name; set => pokemon.Name = value; }
        public string Type { get => pokemon.Type; set => pokemon.Type = value; }
        public string Description { get => pokemon.Description; set => pokemon.Description = value; }
        public int Attack { get => pokemon.Attack; set => pokemon.Attack = value; }
        public int Defense { get => pokemon.Defense; set => pokemon.Defense = value; }
        public int Stamina { get => pokemon.Stamina; set => pokemon.Stamina = value; }
        public string Region { get => pokemon.Region; set => pokemon.Region = value; }
        public int DexNumber { get => pokemon.DexNumber; set => pokemon.DexNumber = value; }
        public string ImageURL { get => pokemon.ImageURL; set => pokemon.ImageURL = value; }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public AddPokemonViewModel(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            Model = new Pokemon();
            AddAction = "Add Pokemon";
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave(object obj)
        {
            var newPokemon = await AddPokemon(pokemon);
            if (newPokemon != null)
            {
                SessionInfo.Instance.Pokemons.Add(newPokemon);
                await App.Current.MainPage.DisplayAlert("Success", "Pokemon added successfully", "OK");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Pokemon not added", "OK");
            }
        }

        private async Task<Pokemon> AddPokemon(Pokemon pokemon)
        {
            pokemon.Id = Guid.NewGuid();
            return await _pokemonService.AddPokemonAsync(pokemon);
        }
    }
}
