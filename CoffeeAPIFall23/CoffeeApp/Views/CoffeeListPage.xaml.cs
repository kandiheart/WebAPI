using CoffeeApp.ViewModels;

namespace CoffeeApp.Views;

public partial class CoffeeListPage : ContentPage
{
	public CoffeeListPage()
	{
		InitializeComponent();
	}

	CoffeeListViewModel ViewModel => BindingContext as CoffeeListViewModel;

	protected override async void OnAppearing()
	{
        base.OnAppearing();
        await ViewModel.OnAppearing();
		coffeeList.ItemsSource = ViewModel.Coffees;
    }
}