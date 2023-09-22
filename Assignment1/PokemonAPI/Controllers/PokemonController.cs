using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokemonAPI.Models;
using static PokemonAPI.Models.Pokemon;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        // GET: api/<PokemonController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> Get()
        {
            string s = System.IO.File.ReadAllText("./pokemon.json");
            PokemonList pokemons = JsonConvert.DeserializeObject<PokemonList>(s);
            return pokemons.Pokemons;
        }

        // GET api/<PokemonController>/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(Guid Id)
        {
            string s = System.IO.File.ReadAllText("./pokemon.json");
            PokemonList pokemons = JsonConvert.DeserializeObject<PokemonList>(s);

            var pokemon = pokemons.Pokemons.FirstOrDefault(p => p.Id == Id);
            return Ok(pokemon);
        }

        // POST api/<PokemonController>
        [HttpPost]
        public async Task<ActionResult<Pokemon>> PostPokemon([FromBody] Pokemon pokemon)
        {
            string s = System.IO.File.ReadAllText("./pokemon.json");
            PokemonList pokemons = JsonConvert.DeserializeObject<PokemonList>(s);

            pokemons.Pokemons.Add(pokemon);

            string newJson = JsonConvert.SerializeObject(pokemons, Formatting.Indented);
            System.IO.File.WriteAllText("./pokemon.json", newJson);

            CreatedAtAction(nameof(GetPokemon), new { Id = pokemon.Id }, pokemon);

            return Ok(pokemon);
        }

        // PUT api/<PokemonController>/5
        [HttpPut("{Id}")]
        public async Task<ActionResult<Pokemon>> UpdatePokemon(Guid Id, [FromBody] Pokemon pokemon)
        {
            if (pokemon == null)
            {
                return BadRequest("Invalid Data");
            }

            string s = System.IO.File.ReadAllText("./pokemon.json");
            PokemonList pokemons = JsonConvert.DeserializeObject<PokemonList>(s);

            var Foundpokemon = pokemons.Pokemons.FirstOrDefault(p => p.Id == Id);
            if (Foundpokemon == null)
            {
                return NotFound("Error updating data, Pokemon Id mismatch");
            }

            Foundpokemon.Id = Id;
            if (pokemon.Name != "string") Foundpokemon.Name = pokemon.Name;
            if (pokemon.Description != "string") Foundpokemon.Description = pokemon.Description;
            if (pokemon.Type != "string") Foundpokemon.Type = pokemon.Type;
            if (pokemon.Attack != 0) Foundpokemon.Attack = pokemon.Attack;
            if (pokemon.Defense != 0) Foundpokemon.Defense = pokemon.Defense;
            if (pokemon.Stamina != 0) Foundpokemon.Stamina = pokemon.Stamina;
            if (pokemon.Region != "string") Foundpokemon.Region = pokemon.Region;
            if (pokemon.DexNumber != 0) Foundpokemon.DexNumber = pokemon.DexNumber;

            string newJson = JsonConvert.SerializeObject(pokemons, Formatting.Indented);
            System.IO.File.WriteAllText("./pokemon.json", newJson);
            return Foundpokemon;

        }

        // DELETE api/<PokemonController>/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Pokemon>> DeletePokemon(Guid Id)
        {
            string s = System.IO.File.ReadAllText("./pokemon.json");
            PokemonList pokemons = JsonConvert.DeserializeObject<PokemonList>(s);

            var Foundpokemon = pokemons.Pokemons.FirstOrDefault(p => p.Id == Id);
            if (Foundpokemon == null)
            {
                return NotFound($"Pokemon with Id = {Id} not found");
            }

            pokemons.Pokemons.Remove(Foundpokemon);
            string newJson = JsonConvert.SerializeObject(pokemons, Formatting.Indented);
            System.IO.File.WriteAllText("./pokemon.json", newJson);
            return Ok(Foundpokemon);
        }
    }
}
