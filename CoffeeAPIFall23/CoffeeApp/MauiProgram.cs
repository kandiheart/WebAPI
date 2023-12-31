﻿using CoffeeApp.Models;
using CoffeeApp.Services;
using CoffeeApp.ViewModels;
using CoffeeApp.Views;
using CommonServiceLocator;
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
            builder.Services.AddSingleton<SessionInfo>();
            builder.Services.AddTransient<IDataStore<Item>, MockDataStore>();
            builder.Services.AddTransient<ICoffeeService, CoffeeService>();

            // Register ViewModels
            builder.Services.AddTransient<BasePageViewModel, BasePageViewModel>();
            builder.Services.AddTransient<BaseViewModel, BaseViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<AboutViewModel>();

            builder.Services.AddSingleton<CoffeeListViewModel>();
            builder.Services.AddSingleton<AddBeverageViewModel<Coffee>>();
            builder.Services.AddSingleton<AddCoffeeViewModel>();

            builder.Services.AddSingleton<ItemsViewModel>();
            builder.Services.AddSingleton<ItemDetailViewModel>();                    


#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}