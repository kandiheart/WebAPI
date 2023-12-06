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

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get => Pokemon.Name; set => Pokemon.Name = value; }
        public string Type { get => Pokemon.Type; set => Pokemon.Type = value; }
        public string Description { get => Pokemon.Description; set => Pokemon.Description = value; }
        public int Attack { get => Pokemon.Attack; set => Pokemon.Attack = value; }
        public int Defense { get => Pokemon.Defense; set => Pokemon.Defense = value; }
        public int Stamina { get => Pokemon.Stamina; set => Pokemon.Stamina = value; }
        public string Region { get => Pokemon.Region; set => Pokemon.Region = value; }
        [Required(ErrorMessage = "Dex Number is required")]
        public int DexNumber { get => Pokemon.DexNumber; set => Pokemon.DexNumber = value; }
        [Required(ErrorMessage = "Image URL is required")]
        [Url(ErrorMessage = "Image URL must be a valid URL")]
        public string ImageURL { get => Pokemon.ImageURL; set => Pokemon.ImageURL = value; }

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
            await Shell.Current.GoToAsync("//pokemons");
        }

        private async void OnSave(object obj)
        {
            var newPokemon = await UpdatePokemon(Pokemon);
            if (newPokemon != null)
            {
                SessionInfo.Instance.Pokemons.Add(newPokemon);
                //await DisplayAlert("Success", "Pokemon updated successfully", "OK");
                await Shell.Current.GoToAsync("//pokemons");
            }
            else
            {
                //await App.Current.MainPage.DisplayAlert("Error", "Pokemon not updated", "OK");
                await Shell.Current.GoToAsync("//about");
            }
        }

        private async Task<Pokemon> UpdatePokemon(Pokemon pokemon)
        {
            return await _service.UpdatePokemonAsync(pokemon);
        }
    }
}
