namespace CoffeeAPIFall23.Models
{
    public class Coffee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Characteristic { get; set; }
        public string Strength { get; set; }
        public decimal? Cost { get; set; }
        public string ImageURL { get; set; }
        public class CoffeeList
        {
            public List<Coffee> Coffees;
        }
    }
}
