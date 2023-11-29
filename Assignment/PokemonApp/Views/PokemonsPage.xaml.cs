using PokemonApp.Models;
using PokemonApp.Services;
using PokemonApp.ViewModels;

namespace PokemonApp.Views;

public partial class PokemonsPage : ContentPage
{
	private readonly PokemonListViewModel _viewModel;
	private readonly IPokemonService _service;

	public PokemonsPage()
	{
		_service = MauiProgram.CreateMauiApp().Services.GetService<IPokemonService>();
		InitializeComponent();
		_viewModel = new PokemonListViewModel(_service);
		
        BindingContext = _viewModel;
    }
}