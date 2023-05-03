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
    public class PersonnelsController : ControllerBase
    {
        private readonly DMVContext _context;

        public PersonnelsController(DMVContext context)
        {
            _context = context;
        }

        // GET: api/Personnels
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personnel>>> GetPersonnel()
        {
          if (_context.Personnel == null)
          {
              return NotFound();
          }
            return await _context.Personnel.ToListAsync();
        }

        // GET: api/Personnels/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Personnel>> GetPersonnel(string id)
        {
          if (_context.Personnel == null)
          {
              return NotFound();
          }
            var personnel = await _context.Personnel.FindAsync(id);

            if (personnel == null)
            {
                return NotFound();
            }

            return personnel;
        }

        // PUT: api/Personnels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonnel(string id, Personnel personnel)
        {
            if (id != personnel.PersonnelId)
            {
                return BadRequest();
            }

            _context.Entry(personnel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonnelExists(id))
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

        // POST: api/Personnels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Personnel>> PostPersonnel(Personnel personnel)
        {
          if (_context.Personnel == null)
          {
              return Problem("Entity set 'DMVContext.Personnel'  is null.");
          }
            _context.Personnel.Add(personnel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonnelExists(personnel.PersonnelId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonnel", new { id = personnel.PersonnelId }, personnel);
        }

        // DELETE: api/Personnels/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonnel(string id)
        {
            if (_context.Personnel == null)
            {
                return NotFound();
            }
            var personnel = await _context.Personnel.FindAsync(id);
            if (personnel == null)
            {
                return NotFound();
            }

            _context.Personnel.Remove(personnel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonnelExists(string id)
        {
            return (_context.Personnel?.Any(e => e.PersonnelId == id)).GetValueOrDefault();
        }
    }
}
