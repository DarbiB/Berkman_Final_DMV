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
    public class DriversController : ControllerBase
    {
        private readonly DMVContext _context;

        public DriversController(DMVContext context)
        {
            _context = context;
        }

        // GET: api/Drivers
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
          if (_context.Drivers == null)
          {
              return NotFound();
          }
            return await _context.Drivers.ToListAsync();
        }

        // GET: api/Drivers/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(string id)
        {
          if (_context.Drivers == null)
          {
              return NotFound();
          }
            var driver = await _context.Drivers.FindAsync(id);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        // GET: api/Drivers?firstName={firstName}&lastName={lastName}
        [Authorize]
        [HttpGet("{firstName},{lastName}")]
        public async Task<ActionResult<Driver>> GetDriverName(string firstName, string lastName)
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }
            var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.DriverFirstName == firstName && d.DriverLastName == lastName);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        // GET: api/Drivers/ssn
        [Authorize]
        [HttpGet("ssn/{ssn}")]
        public async Task<ActionResult<Driver>> GetDriverBySSN(string ssn)
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }
            var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.DriverSsn == ssn);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }


        // GET: api/Drivers/licensePlate
        [Authorize]
        [HttpGet("licenseplate/{licensePlate}")]
        public async Task<ActionResult<Driver>> GetDriverByLicensePlate(string licensePlate)
        {
            var driver = await _context.Drivers
                .Join(
                    _context.Vehicles,
                    driver => driver.DriverId,
                    vehicle => vehicle.DriverId,
                    (driver, vehicle) => new { Driver = driver, Vehicle = vehicle }
                )
                .FirstOrDefaultAsync(x => x.Vehicle.VehiclePlate == licensePlate);

            if (driver == null)
            {
                return NotFound();
            }

            return driver.Driver;
        }



        // PUT: api/Drivers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriver(string id, Driver driver)
        {
            if (id != driver.DriverId)
            {
                return BadRequest();
            }

            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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

            // POST: api/Drivers
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [Authorize(Roles = "DMV")]
            [HttpPost]
            public async Task<ActionResult<Driver>> PostDriver(Driver driver)
            {
              if (_context.Drivers == null)
              {
                  return Problem("Entity set 'DMVContext.Drivers'  is null.");
              }
                _context.Drivers.Add(driver);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (DriverExists(driver.DriverId))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction("GetDriver", new { id = driver.DriverId }, driver);
            }

        // DELETE: api/Drivers/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(string id)
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverExists(string id)
        {
            return (_context.Drivers?.Any(e => e.DriverId == id)).GetValueOrDefault();
        }
    }
}
