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
using System.Data;

namespace Berkman_Final_DMV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversInfractionsController : ControllerBase
    {
        private readonly DMVContext _context;

        public DriversInfractionsController(DMVContext context)
        {
            _context = context;
        }

        // GET: api/DriversInfractions
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriversInfraction>>> GetDriversInfractions()
        {
          if (_context.DriversInfractions == null)
          {
              return NotFound();
          }
            return await _context.DriversInfractions.ToListAsync();
        }

        // GET: api/DriversInfractions/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<DriversInfraction>> GetDriversInfraction(string id)
        {
          if (_context.DriversInfractions == null)
          {
              return NotFound();
          }
            var driversInfraction = await _context.DriversInfractions.FindAsync(id);

            if (driversInfraction == null)
            {
                return NotFound();
            }

            return driversInfraction;
        }

        // PUT: api/DriversInfractions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Law Enforcement")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriversInfraction(string id, DriversInfraction driversInfraction)
        {
            if (id != driversInfraction.InfractionId)
            {
                return BadRequest();
            }

            _context.Entry(driversInfraction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriversInfractionExists(id))
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

        // POST: api/DriversInfractions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Law Enforcement")]
        [HttpPost]
        public async Task<ActionResult<DriversInfraction>> PostDriversInfraction(DriversInfraction driversInfraction)
        {
          if (_context.DriversInfractions == null)
          {
              return Problem("Entity set 'DMVContext.DriversInfractions'  is null.");
          }
            _context.DriversInfractions.Add(driversInfraction);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DriversInfractionExists(driversInfraction.InfractionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDriversInfraction", new { id = driversInfraction.InfractionId }, driversInfraction);
        }

        // DELETE: api/DriversInfractions/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriversInfraction(string id)
        {
            if (_context.DriversInfractions == null)
            {
                return NotFound();
            }
            var driversInfraction = await _context.DriversInfractions.FindAsync(id);
            if (driversInfraction == null)
            {
                return NotFound();
            }

            _context.DriversInfractions.Remove(driversInfraction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriversInfractionExists(string id)
        {
            return (_context.DriversInfractions?.Any(e => e.InfractionId == id)).GetValueOrDefault();
        }
    }
}
