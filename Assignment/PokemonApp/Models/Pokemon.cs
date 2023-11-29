using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Models
{
    public class Pokemon
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 500 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Type is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Type must be between 3 and 50 characters")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Attack is required")]
        [Range(0, 1000, ErrorMessage = "Attack must be between 0 and 1000")]
        public int Attack { get; set; }
        [Required(ErrorMessage = "Defense is required")]
        [Range(0, 1000, ErrorMessage = "Defense must be between 0 and 1000")]
        public int Defense { get; set; }
        [Required(ErrorMessage = "Stamina is required")]
        [Range(0, 1000, ErrorMessage = "Stamina must be between 0 and 1000")]
        public int Stamina { get; set; }
        [Required(ErrorMessage = "Region is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Region must be between 3 and 50 characters")]
        public string Region { get; set; }
        [Required(ErrorMessage = "Dex Number is required")]
        [Range(0, 1000, ErrorMessage = "Dex Number must be between 0 and 1000")]
        public int DexNumber { get; set; }
        [Required(ErrorMessage = "Image URL is required")]
        [Url(ErrorMessage = "Image URL must be a valid URL")]
        public string ImageURL { get; set; }

        public Pokemon() { }

        public class PokemonList
        {
            public List<Pokemon> Pokemons;
        }
    }
}
