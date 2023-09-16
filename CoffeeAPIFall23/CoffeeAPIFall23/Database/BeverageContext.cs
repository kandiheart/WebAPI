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
        }
    }
}
