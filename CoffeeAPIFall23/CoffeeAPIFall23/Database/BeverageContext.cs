using CoffeeAPIFall23.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeAPIFall23.Database
{
    public class BeverageContext: DbContext
    {
        public BeverageContext()
        {
        }

        public BeverageContext(DbContextOptions<BeverageContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Coffee>().Property(c => c.Id).HasDefaultValueSql("NEWID()");
        }

        public DbSet<Coffee> Coffees { get; set; }
    }
}
