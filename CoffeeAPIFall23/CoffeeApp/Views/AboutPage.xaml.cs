using CoffeeApp.ViewModels;

namespace CoffeeApp.Views;

public partial class AboutPage : ContentPage
{
	private readonly AboutViewModel _viewModel;
	public AboutPage()
	{
		InitializeComponent();
		BindingContext = _viewModel = MauiProgram.CreateMauiApp().Services.GetService<AboutViewModel>();
	}
}