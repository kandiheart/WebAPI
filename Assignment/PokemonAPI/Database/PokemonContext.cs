using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PokemonAPI.Models;

namespace PokemonAPI.Database
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemons { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("./appsettings.json")
                .Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var jsonText = File.ReadAllText("./pokemon.json");
            var pokemons = JsonConvert.DeserializeObject<Pokemon.PokemonList>(jsonText);

            foreach (var pokemon in pokemons.Pokemons)
            {
                modelBuilder.Entity<Pokemon>().HasData(pokemon);
            }
        }
    }
}
