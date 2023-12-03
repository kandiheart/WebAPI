using PokemonApp.Models;
using PokemonApp.Services;
using PokemonApp.ViewModels;

namespace PokemonApp.Views;

public partial class PokemonsPage : ContentPage
{
	public PokemonsPage(PokemonListViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var pokemon = ((VisualElement)sender).BindingContext as Pokemon;
        if (pokemon == null)
            return;
        await Shell.Current.GoToAsync(nameof(EditPokemonPage), true, new Dictionary<string, object>
        {
            { "Pokemon", pokemon }
        });
    }
}