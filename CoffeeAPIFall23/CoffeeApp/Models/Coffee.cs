using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Models
{
    internal class Coffee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Characteristic { get; set; }
        public string Strength { get; set; }
        public double Cost { get; set; }
        public string ImageURL {  get; set; }
        public string CostString => $"Cost: ${Cost}";
        public class CoffeeList
        {
            public List<Coffee> Coffees { get; set; }
        }
    }
}
