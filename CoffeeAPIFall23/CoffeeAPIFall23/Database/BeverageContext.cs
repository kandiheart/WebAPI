using CoffeeAPIFall23.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeAPIFall23.Database
{
    public class BeverageContext: DbContext
    {

        public BeverageContext(DbContextOptions<BeverageContext> options) : base(options)
        {
        }

        public DbSet<Coffee> Coffees { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coffee>().HasData(
                new Coffee
                {
                    Id = Guid.NewGuid(),
                    Name = "Cappuccino",
                    Characteristic = "Espresso, steamed milk, and milk foam",
                    Strength = "Medium",
                    Cost = 3.45M,
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg"
                }, new Coffee
                {
                    Id = Guid.NewGuid(),
                    Name = "Espresso",
                    Characteristic = "Espresso",
                    Strength = "Strong",
                    Cost = 2.45M,
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg"
                }, new Coffee
                {
                    Id = Guid.NewGuid(),
                    Name = "Latte",
                    Characteristic = "Espresso and steamed milk",
                    Strength = "Medium",
                    Cost = 3.45M,
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg"
                }, new Coffee
                {
                    Id = Guid.NewGuid(),
                    Name = "Mocha",
                    Characteristic = "Espresso, steamed milk, milk foam, and chocolate",
                    Strength = "Medium",
                    Cost = 3.45M,
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg"
                }, new Coffee
                {
                    Id = Guid.NewGuid(),
                    Name = "Americano",
                    Characteristic = "Espresso and hot water",
                    Strength = "Medium",
                    Cost = 3.45M,
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg"
                }, new Coffee
                {
                    Id = Guid.NewGuid(),
                    Name = "Macchiato",
                    Characteristic = "Espresso and milk foam",
                    Strength = "Medium",
                    Cost = 3.45M,
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg"
                }, new Coffee
                {
                    Id = Guid.NewGuid(),
                    Name = "Cortado",
                    Characteristic = "Espresso and steamed milk",
                    Strength = "Medium",
                    Cost = 3.45M,
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg"
                });
        }
    }
}
