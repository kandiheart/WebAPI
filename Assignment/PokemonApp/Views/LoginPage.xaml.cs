using PokemonApp.ViewModels;

namespace PokemonApp.Views;

public partial class LoginPage : ContentPage
{
	private readonly LoginPageViewModel _viewModel;
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = _viewModel = MauiProgram.CreateMauiApp().Services.GetService<LoginPageViewModel>();
	}
}