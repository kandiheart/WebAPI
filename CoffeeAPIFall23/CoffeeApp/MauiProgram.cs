using CoffeeApp.Models;
using CoffeeApp.Services;
using CoffeeApp.ViewModels;
using CoffeeApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoffeeApp
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
            builder.Services.AddSingleton<IDataStore<Item>, MockDataStore>();
            builder.Services.AddSingleton<ICoffeeService, CoffeeService>();
            //builder.Services.AddSingletone<ICoffeeStore, CoffeeStore>();

            // Register ViewModels
            builder.Services.AddSingleton<BaseViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<AboutViewModel>();
            builder.Services.AddSingleton<CoffeeListViewModel>();

            // Register Views
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<AboutPage>();
            


#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}