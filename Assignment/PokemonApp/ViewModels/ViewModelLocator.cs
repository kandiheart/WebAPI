using CommonServiceLocator;
using PokemonApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.ViewModels
{
    internal class ViewModelLocator
    {
        //private static readonly IPokemonService Service = ServiceLocator.Current.GetInstance<IPokemonService>();
        public ViewModelLocator()
        {
        }

        // these do not work
        /*public LoginPageViewModel LoginVM => ServiceLocator.Current.GetInstance<LoginPageViewModel>();
        public AboutViewModel AboutVM => ServiceLocator.Current.GetInstance<AboutViewModel>();
        public PokemonListViewModel PokemonListVM => ServiceLocator.Current.GetInstance<PokemonListViewModel>();
        public AddPokemonViewModel AddPokemonVM => ServiceLocator.Current.GetInstance<AddPokemonViewModel>();*/


    }
}
