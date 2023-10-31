using CoffeeApp.ViewModels;

namespace CoffeeApp.Views;

public partial class CoffeeListPage : ContentPage
{
	private readonly CoffeeListViewModel _viewModel;
	public CoffeeListPage()
	{
		InitializeComponent();
		_viewModel = new CoffeeListViewModel();
	}

	CoffeeListViewModel ViewModel => BindingContext as CoffeeListViewModel;

	protected override async void OnAppearing()
	{
        base.OnAppearing();
        await ViewModel.OnAppearing();
		coffeeList.ItemsSource = ViewModel.Coffees;
    }
}