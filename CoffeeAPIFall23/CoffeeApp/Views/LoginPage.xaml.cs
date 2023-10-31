using CoffeeApp.ViewModels;

namespace CoffeeApp.Views;

public partial class LoginPage : ContentPage
{
	private readonly LoginPageViewModel _viewModel;
	public LoginPage()
	{
		InitializeComponent();
		_viewModel = MauiProgram.CreateMauiApp().Services.GetService<LoginPageViewModel>();
		BindingContext = _viewModel;
	}
}