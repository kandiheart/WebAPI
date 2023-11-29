using PokemonApp.Views;

namespace PokemonApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Routing.RegisterRoute("pokemons", typeof(PokemonsPage));
            Routing.RegisterRoute("newpokemon", typeof(NewPokemonPage));
            Routing.RegisterRoute("pokemon", typeof(PokemonDetailPage));
            Routing.RegisterRoute("editpokemon", typeof(EditPokemonPage));
            Routing.RegisterRoute("deletepokemon", typeof(DeletePokemonPage));
            Routing.RegisterRoute("about", typeof(AboutPage));
            Routing.RegisterRoute("login", typeof(LoginPage));
        }
    }
}