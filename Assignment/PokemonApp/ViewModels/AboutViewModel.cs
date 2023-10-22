using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokemonApp.ViewModels
{
    internal class AboutViewModel: BaseViewModel
    {
        public AboutViewModel() : base()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://pokemon.gameinfo.io/"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
