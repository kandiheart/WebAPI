using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.ViewModels
{
    internal class AddBeverageViewModel<T>: BaseViewModel where T: class
    {
        protected object Model;

        public string AddAction { get; set; }

        public AddBeverageViewModel(T obj)
        {
            Model = obj;
        }

        virtual public Task<T> AddBeverage(T obj)
        {
            return Task.FromResult(obj);
        }
    }
}
