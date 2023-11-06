using PokemonApp.ViewModels;

namespace PokemonApp.Views;

public partial class NewPokemonPage : ContentPage
{
	private readonly AddPokemonViewModel _viewModel;
	public NewPokemonPage()
	{
		InitializeComponent();
		BindingContext = _viewModel = MauiProgram.CreateMauiApp().Services.GetService<AddPokemonViewModel>();
	}
}