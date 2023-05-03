using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Berkman_Final_DMV.Data;
using Berkman_Final_DMV.Models;
using Microsoft.AspNetCore.Authorization;

namespace Berkman_Final_DMV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfractionsController : ControllerBase
    {
        private readonly DMVContext _context;

        public InfractionsController(DMVContext context)
        {
            _context = context;
        }

        // GET: api/Infractions
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Infraction>>> GetInfractions()
        {
          if (_context.Infractions == null)
          {
              return NotFound();
          }
            return await _context.Infractions.ToListAsync();
        }

        // GET: api/Infractions/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Infraction>> GetInfraction(string id)
        {
          if (_context.Infractions == null)
          {
              return NotFound();
          }
            var infraction = await _context.Infractions.FindAsync(id);

            if (infraction == null)
            {
                return NotFound();
            }

            return infraction;
        }

        // PUT: api/Infractions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfraction(string id, Infraction infraction)
        {
            if (id != infraction.InfractionId)
            {
                return BadRequest();
            }

            _context.Entry(infraction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfractionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Infractions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Infraction>> PostInfraction(Infraction infraction)
        {
          if (_context.Infractions == null)
          {
              return Problem("Entity set 'DMVContext.Infractions'  is null.");
          }
            _context.Infractions.Add(infraction);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InfractionExists(infraction.InfractionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInfraction", new { id = infraction.InfractionId }, infraction);
        }

        // DELETE: api/Infractions/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfraction(string id)
        {
            if (_context.Infractions == null)
            {
                return NotFound();
            }
            var infraction = await _context.Infractions.FindAsync(id);
            if (infraction == null)
            {
                return NotFound();
            }

            _context.Infractions.Remove(infraction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfractionExists(string id)
        {
            return (_context.Infractions?.Any(e => e.InfractionId == id)).GetValueOrDefault();
        }
    }
}
