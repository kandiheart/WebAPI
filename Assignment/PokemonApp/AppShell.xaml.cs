using PokemonApp.Views;

namespace PokemonApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("about", typeof(AboutPage));
            Routing.RegisterRoute("pokemons", typeof(PokemonsPage));
            Routing.RegisterRoute("newpokemon", typeof(NewPokemonPage));
        }
    }
}