using PokemonApp.Services;
using PokemonApp.ViewModels;

namespace PokemonApp.Views;

public partial class NewPokemonPage : ContentPage
{
	private readonly AddPokemonViewModel _viewModel;
    private readonly IPokemonService _service;
	public NewPokemonPage()
	{
        _service = MauiProgram.CreateMauiApp().Services.GetService<IPokemonService>();
        InitializeComponent();
        _viewModel = new AddPokemonViewModel(_service);

        BindingContext = _viewModel;
    }
}