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
    [ApiController]
    public class CandidatController : Controller
    {
        // Declaring rh database context on private and read only
        private RHDbContext rhContext = new RHDbContext();

        // GET: api/<controller>. Gets all candidates and attributes from database via an asynchronous action
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidat>>> GetCanditatesAsync()
        {
            // Awaiting for context to retrieve all informations on database
            return await rhContext.Candidat.ToListAsync();
        }

        // GET: api/<controller>/5. Gets the specified indexed candidate
        [HttpGet("{idCandidat}")]
        public async Task<ActionResult<Candidat>> GetCandidateAsync(int idCandidat)
        {

            var candidat = await rhContext.Candidat.FindAsync(idCandidat);

            if(candidat == null)
            {
                return NotFound(); // Returning an not found exception when there's no candidate with the specified id
                // NotFound returns a 404 status as an answer
            }

            return candidat; // Returning the specified candidate

        }

        // POST: api/<controller>. Post a new candidate from form body to the database
        [HttpPost]
        public async Task<ActionResult<Candidat>> PostCandidate([FromBody]Candidat candidat)
        {
            // Adding the candidate object to the database
            rhContext.Candidat.Add(candidat);
            await rhContext.SaveChangesAsync(); // ReSynchronizing the database just after insertion

            return CreatedAtAction(nameof(GetCandidateAsync), new { id = candidat.IdCandidat }, candidat); // return the created action
        }

        // PUT api/<controller>/5
        [HttpPut("{idCandidate}")]
        public async Task<IActionResult> PutCandidate(int idCandidate, [FromBody]Candidat candidat)
        {
            if(idCandidate != candidat.IdCandidat)
            {
                return BadRequest();
            }

            rhContext.Entry(candidat).State = EntityState.Modified;
            await rhContext.SaveChangesAsync();

            return NoContent();
        }

        /*
         * Commenting out the delete method, think it's not necessary for now 15/03/2019
         */

        /*// DELETE api/<controller>/5
        [HttpDelete("{idCandidat}")]
        public async Task<IActionResult> DeleteTodoItem(int idCandidat)
        {
            var candidat = await _context.Candidat.FindAsync(idCandidat);

            if (candidat == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(candidat);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/
    }
}
