using PokemonApp.Services;
using PokemonApp.ViewModels;

namespace PokemonApp.Views;

public partial class LoginPage : ContentPage
{
	private readonly LoginPageViewModel _viewModel;
    private readonly IPokemonService _service;
	public LoginPage()
	{
        _service = MauiProgram.CreateMauiApp().Services.GetService<IPokemonService>();
        InitializeComponent();
        _viewModel = new LoginPageViewModel(_service);

        BindingContext = _viewModel;
    }
}