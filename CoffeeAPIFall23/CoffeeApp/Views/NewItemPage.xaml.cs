using CoffeeApp.Models;
using CoffeeApp.ViewModels;

namespace CoffeeApp.Views;

public partial class NewItemPage : ContentPage
{
	private readonly AddCoffeeViewModel _viewModel;
	public NewItemPage()
	{
		InitializeComponent();
		//_viewModel = new AddCoffeeViewModel();
		BindingContext = _viewModel;
	}
}