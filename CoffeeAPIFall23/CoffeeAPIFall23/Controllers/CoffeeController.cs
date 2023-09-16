using CoffeeAPIFall23.Database;
using CoffeeAPIFall23.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static CoffeeAPIFall23.Models.Coffee;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeAPIFall23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly BeverageContext _context;

        public CoffeeController(BeverageContext context)
        {
            _context = context;
        }

        // GET: api/<CoffeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coffee>>> Get() 
        {
            if (_context != null)
            {
                if (_context.Coffees == null)
                {
                    return NotFound();
                }

                var result = _context.Coffees;
                return await _context.Coffees.ToListAsync();
            }
            else
            {
                // read json file
                string s = System.IO.File.ReadAllText("./coffees.json");
                CoffeeList coffeeList = JsonConvert.DeserializeObject<CoffeeList>(s);
                IEnumerable<Coffee> result = coffeeList.Coffees;
                return Ok(result);
            }
        }

        // GET api/<CoffeeController>/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Coffee>> GetCoffee(Guid Id)
        {
            string s = System.IO.File.ReadAllText("./coffees.json");
            CoffeeList coffeeList = JsonConvert.DeserializeObject<CoffeeList>(s);

            // find coffee with matching Id
            var inivCoffee = coffeeList.Coffees.FirstOrDefault(c=>c.Id==Id);
            // if no coffee found, return 404
            return Ok(inivCoffee);
        }

        // POST api/<CoffeeController>
        [HttpPost]
        public async Task<ActionResult<Coffee>> PostCoffee([FromBody] Coffee coffee)
        {
            // read json file
            string s = System.IO.File.ReadAllText("./coffees.json");
            CoffeeList coffeeList = JsonConvert.DeserializeObject<CoffeeList>(s);

            // add coffee to list
            coffeeList.Coffees.Add(coffee);

            // write json file
            string newJson = JsonConvert.SerializeObject(coffeeList, Formatting.Indented);
            System.IO.File.WriteAllText("./coffees.json", newJson);

            // return 201 Created status code
            //return CreatedAtAction(nameof(GetCoffee), new { Id = coffee.Id }, coffee);

            // return 200 OK status code
            return Ok(coffee);
        }

        // PUT api/<CoffeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CoffeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
