using PokemonApp.ViewModels;

namespace PokemonApp.Views;

public partial class AboutPage : ContentPage
{
	private readonly AboutViewModel _viewModel;
	public AboutPage()
	{
		InitializeComponent();
		BindingContext = _viewModel = MauiProgram.CreateMauiApp().Services.GetService<AboutViewModel>();
	}
}