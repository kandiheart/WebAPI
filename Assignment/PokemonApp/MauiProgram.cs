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

            /*// Register ViewModels
            builder.Services.AddTransient<BaseViewModel, BaseViewModel>();
            builder.Services.AddTransient<BasePageViewModel, BasePageViewModel>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<AboutViewModel>();

            builder.Services.AddSingleton<PokemonListViewModel>();
            builder.Services.AddSingleton<AddPokemonViewModel>();

            // Register Views
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<AboutPage>();

            builder.Services.AddSingleton<PokemonsPage>();
            builder.Services.AddSingleton<NewPokemonPage>();
            //builder.Services.AddSingleton<PokemonDetailPage>();
            //builder.Services.AddSingleton<EditPokemonPage>();
            //builder.Services.AddSingleton<DeletePokemonPage>();*/

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}