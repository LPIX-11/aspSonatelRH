using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SonatelRH.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SonatelRH.Controllers
{
    [Route("api/[controller]")]
    public class DirectionController : Controller
    {
        // Declaring rh database context on private and read only
        private RHDbContext rhContext = new RHDbContext();

        // GET: api/<controller>. Gets all directions and attributes from database via an asynchronous action
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Direction>>> GetAllDirectionAsync()
        {
            // Awaiting for context to retrieve all informations on database
            return await rhContext.Direction.ToListAsync();
        }

        // GET direction by id
        [HttpGet("{idDirection}")]
        public async Task<ActionResult<Direction>> GetDirectionByIdAsync(int idDirection)
        {

            var direction = await rhContext.Direction.FindAsync(idDirection);

            if (direction == null)
            {
                return NotFound(); // direction not found
            }

            return direction; // Returning the specified direction

        }

        //  Post a new direction from form body to the database
        [HttpPost]
        public async Task<ActionResult<Direction>> PostDirection([FromBody]Direction direction)
        {
            // Adding the direction object to the database
            rhContext.Direction.Add(direction);
            await rhContext.SaveChangesAsync(); // ReSynchronizing the database just after insertion

            return CreatedAtAction(nameof(GetDirectionByIdAsync), new { id = direction.IdDirection }, direction); // return the created action
        }

        // PUT: methode to update direction
        [HttpPut("{idDirection}")]
        public async Task<IActionResult> UpdateDirection(long idDirection, [FromBody] Direction direction)
        {
            //it is necessary to have the direction for know what we apply the update
            if (idDirection != direction.IdDirection)
            {
                return BadRequest(); // this direction don't correspond a direction in  the database 
            }

            rhContext.Entry(direction).State = EntityState.Modified;
            await rhContext.SaveChangesAsync(); //Save the change of the same direction in the database

            return NoContent();
        }
    }
}
