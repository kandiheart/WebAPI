using PokemonApp.ViewModels;

namespace PokemonApp.Views;

public partial class EditPokemonPage : ContentPage
{
	public EditPokemonPage(PokemonDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}