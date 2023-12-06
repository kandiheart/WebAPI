using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PokemonAPI.Database;
using PokemonAPI.Models;
using static PokemonAPI.Models.Pokemon;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonContext _context;

        private PokemonList? pokemons = new PokemonList();

        public PokemonController(PokemonContext context)
        {
            _context = context;
        }

        // GET: api/<PokemonController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> Get()
        {
            if (_context != null)
            {
                if (_context.Pokemons == null)
                {
                    return NotFound();
                }

                var result = await _context.Pokemons.ToListAsync();
                return result;
            }
            else
            {
                string s = System.IO.File.ReadAllText("./pokemon.json");
                this.pokemons = JsonConvert.DeserializeObject<PokemonList>(s);
                return Ok(pokemons.Pokemons);
            }
        }

        // GET api/<PokemonController>/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(Guid Id)
        {
            if (_context != null)
            {
                if (_context.Pokemons == null)
                {
                    return NotFound();
                }

                var result = await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == Id);
                return Ok(result);
            }
            else
            {
                string s = System.IO.File.ReadAllText("./pokemon.json");
                this.pokemons = JsonConvert.DeserializeObject<PokemonList>(s);

                var pokemon = this.pokemons.Pokemons.FirstOrDefault(p => p.Id == Id);
                return Ok(pokemon);
            }
        }

        // POST api/<PokemonController>
        [HttpPost]
        public async Task<ActionResult<Pokemon>> PostPokemon([FromBody] Pokemon pokemon)
        {
            if (_context != null)
            {
                if (_context.Pokemons == null)
                {
                    return NotFound();
                }

                await _context.Pokemons.AddAsync(pokemon);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPokemon), new { Id = pokemon.Id }, pokemon);
            }
            else
            {
                string s = System.IO.File.ReadAllText("./pokemon.json");
                this.pokemons = JsonConvert.DeserializeObject<PokemonList>(s);

                this.pokemons.Pokemons.Add(pokemon);

                string newJson = JsonConvert.SerializeObject(this.pokemons, Formatting.Indented);
                System.IO.File.WriteAllText("./pokemon.json", newJson);

                return CreatedAtAction(nameof(GetPokemon), new { pokemon.Id }, pokemon);
            }
        }

        // PUT api/<PokemonController>/5
        [HttpPut("{Id}")]
        public async Task<ActionResult<Pokemon>> UpdatePokemon(Guid Id, [FromBody] Pokemon pokemon)
        {
            if (pokemon == null)
            {
                return BadRequest("Invalid Data");
            }

            if (_context != null)
            {
                if (_context.Pokemons == null)
                {
                    return NotFound();
                }

                var Foundpokemon = await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == Id);
                if (Foundpokemon == null)
                {
                    return NotFound("Error updating data, Pokemon Id mismatch");
                }

                if (pokemon.Name != "string") Foundpokemon.Name = pokemon.Name;
                if (pokemon.Description != "string") Foundpokemon.Description = pokemon.Description;
                if (pokemon.Type != "string") Foundpokemon.Type = pokemon.Type;
                if (pokemon.Attack != 0) Foundpokemon.Attack = pokemon.Attack;
                if (pokemon.Defense != 0) Foundpokemon.Defense = pokemon.Defense;
                if (pokemon.Stamina != 0) Foundpokemon.Stamina = pokemon.Stamina;
                if (pokemon.Region != "string") Foundpokemon.Region = pokemon.Region;
                if (pokemon.DexNumber != 0) Foundpokemon.DexNumber = pokemon.DexNumber;
                if (pokemon.ImageURL != "string") Foundpokemon.ImageURL = pokemon.ImageURL;

                await _context.SaveChangesAsync();
                return Foundpokemon;
            }
            else
            {
                string s = System.IO.File.ReadAllText("./pokemon.json");
                this.pokemons = JsonConvert.DeserializeObject<PokemonList>(s);

                var Foundpokemon = this.pokemons.Pokemons.FirstOrDefault(p => p.Id == Id);
                if (Foundpokemon == null)
                {
                    return NotFound("Error updating data, Pokemon Id mismatch");
                }

                if (pokemon.Name != "string") Foundpokemon.Name = pokemon.Name;
                if (pokemon.Description != "string") Foundpokemon.Description = pokemon.Description;
                if (pokemon.Type != "string") Foundpokemon.Type = pokemon.Type;
                if (pokemon.Attack != 0) Foundpokemon.Attack = pokemon.Attack;
                if (pokemon.Defense != 0) Foundpokemon.Defense = pokemon.Defense;
                if (pokemon.Stamina != 0) Foundpokemon.Stamina = pokemon.Stamina;
                if (pokemon.Region != "string") Foundpokemon.Region = pokemon.Region;
                if (pokemon.DexNumber != 0) Foundpokemon.DexNumber = pokemon.DexNumber;
                if (pokemon.ImageURL != "string") Foundpokemon.ImageURL = pokemon.ImageURL;

                string newJson = JsonConvert.SerializeObject(pokemons, Formatting.Indented);
                System.IO.File.WriteAllText("./pokemon.json", newJson);
                return Foundpokemon;
            }

        }

        // DELETE api/<PokemonController>/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Pokemon>> DeletePokemon(Guid Id)
        {
            if (_context != null)
            {
                if (_context.Pokemons == null)
                {
                    return NotFound();
                }

                var Foundpokemon = await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == Id);
                if (Foundpokemon == null)
                {
                    return NotFound($"Pokemon with Id = {Id} not found");
                }

                _context.Pokemons.Remove(Foundpokemon);
                await _context.SaveChangesAsync();
                return Ok(Foundpokemon);
            }
            else
            {
                string s = System.IO.File.ReadAllText("./pokemon.json");
                this.pokemons = JsonConvert.DeserializeObject<PokemonList>(s);

                var Foundpokemon = this.pokemons.Pokemons.FirstOrDefault(p => p.Id == Id);
                if (Foundpokemon == null)
                {
                    return NotFound($"Pokemon with Id = {Id} not found");
                }

                pokemons.Pokemons.Remove(Foundpokemon);
                string newJson = JsonConvert.SerializeObject(this.pokemons, Formatting.Indented);
                System.IO.File.WriteAllText("./pokemon.json", newJson);
                return Ok(Foundpokemon);
            }
        }
    }
}
