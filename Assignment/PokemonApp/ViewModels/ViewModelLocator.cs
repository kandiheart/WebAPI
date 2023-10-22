using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.ViewModels
{
    internal class ViewModelLocator
    {
        public ViewModelLocator()
        {
        }

        public LoginPageViewModel LoginVM => ServiceLocator.Current.GetInstance<LoginPageViewModel>();
    }
}
