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
        private readonly RHDbContext rhContext = new RHDbContext();

        // GET: api/<controller>. Gets all directions and attributes from database via an asynchronous action
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Direction>>> GetAllDirectionAsync()
        {
            // Awaiting for context to retrieve all informations on database
            return await rhContext.Direction.ToListAsync();
        }

        // GET direction by id
        [HttpGet("{id}")]
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
    }
}
