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

        public LoginPageViewModel LoginVM => ServiceLocator.Current.GetInstance<LoginPageViewModel>();

        public CoffeeListViewModel CoffeeListVM => ServiceLocator.Current.GetInstance<CoffeeListViewModel>();

        public AddCoffeeViewModel AddCoffeeVM => ServiceLocator.Current.GetInstance<AddCoffeeViewModel>();

        public ItemsViewModel ItemsVM => ServiceLocator.Current.GetInstance<ItemsViewModel>();
    }
}
