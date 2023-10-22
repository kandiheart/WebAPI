using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Models
{
    internal class Pokemon
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Stamina { get; set; }
        public string Region { get; set; }
        public int DexNumber { get; set; }
        public string ImageURL { get; set; }

        public Pokemon() { }

        public class PokemonList
        {
            public List<Pokemon> Pokemons;
        }
    }
}
