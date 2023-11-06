using PokemonApp.ViewModels;

namespace PokemonApp.Views;

public partial class PokemonsPage : ContentPage
{
	private readonly PokemonListViewModel _viewModel;
	public PokemonsPage()
	{
		InitializeComponent();
		BindingContext = _viewModel = MauiProgram.CreateMauiApp().Services.GetService<PokemonListViewModel>();
	}
}