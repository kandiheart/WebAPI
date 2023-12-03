using CommunityToolkit.Mvvm.ComponentModel;
using PokemonApp.Models;
using PokemonApp.Services;
using PokemonApp.ViewModels;
using PokemonApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokemonApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel() { }

        [ObservableProperty]
        bool isBusy;

        public bool IsNotBusy => !IsBusy;

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) { return false; }
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        private string _title = string.Empty;

        public string Title { get => _title; set { SetProperty(ref _title, value); } }
    }
}
