using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.ViewModels
{
    internal class ViewModelLocator
    {
        public ViewModelLocator()
        {
            
        }

        // ServiceLocator.Current.GetInstance<ViewModel>(); did not work because the provider is not set. Can use the code below instead.

        //public LoginPageViewModel LoginVM => Application.Current.Handler.MauiContext.Services.GetService(typeof(LoginPageViewModel)) as LoginPageViewModel;

        //public CoffeeListViewModel CoffeeListVM => Application.Current.Handler.MauiContext.Services.GetService(typeof(CoffeeListViewModel)) as CoffeeListViewModel;

        //public AddCoffeeViewModel AddCoffeeVM => Application.Current.Handler.MauiContext.Services.GetService(typeof(AddCoffeeViewModel)) as AddCoffeeViewModel;

        //public ItemsViewModel ItemsVM => Application.Current.Handler.MauiContext.Services.GetService(typeof(ItemsViewModel)) as ItemsViewModel;
    }
}
