using CoffeeApp.Models;
using CoffeeApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.ViewModels
{
    internal class BaseViewModel: INotifyPropertyChanged
    {
        private readonly IDataStore<Item> _dataStore;
        public BaseViewModel(IDataStore<Item> dataStore) 
        {
            _dataStore = dataStore;
        }

        bool isBusy = false;
        public bool IsBusy {  get { return isBusy; } set { SetProperty(ref isBusy, value); } }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", System.Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) return false;
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return _title; } 
            set
            {
                SetProperty(ref _title, value);
            }
        }

        

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
