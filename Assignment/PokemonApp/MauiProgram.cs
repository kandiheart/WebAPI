using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;
using PokemonApp.Models;
using PokemonApp.Services;
using PokemonApp.ViewModels;
using PokemonApp.Views;

namespace PokemonApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            

            // Register Services
            builder.Services.AddSingleton(new AppSettings
            {
                APIURL = "http://10.0.2.2:5249"
            });
            builder.Services.AddSingleton<IPokemonService, PokemonService>();
            builder.Services.AddSingleton<SessionInfo>();

            builder.Services.AddTransient<PokemonsPage> ();
            builder.Services.AddTransient<PokemonListViewModel> ();

            builder.Services.AddTransient<NewPokemonPage> ();
            builder.Services.AddTransient<AddPokemonViewModel> ();

            builder.Services.AddTransient<EditPokemonPage> ();
            builder.Services.AddTransient<PokemonDetailViewModel> ();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}