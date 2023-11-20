using PokemonApp.Models;
using PokemonApp.Services;
using PokemonApp.ViewModels;

namespace PokemonApp.Views;

public partial class PokemonsPage : ContentPage
{
	private readonly PokemonListViewModel _viewModel;

	public PokemonsPage(IPokemonService service)
	{
		InitializeComponent();
		_viewModel = new PokemonListViewModel(service);
		
        BindingContext = _viewModel;

    }
}