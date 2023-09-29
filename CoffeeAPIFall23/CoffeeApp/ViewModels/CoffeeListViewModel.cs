using CoffeeApp.Models;
using CoffeeApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoffeeApp.ViewModels
{
    internal class CoffeeListViewModel : BaseViewModel
    {
        private ICoffeeService _coffeeService;
        public ICommand AddItemCommand { get; }

        public List<Coffee> Coffees => SessionInfo.Instance.Coffees?.ToList();
        public CoffeeListViewModel() : base(null)
        {
            Title = "Coffee List";
        }
    }
}
