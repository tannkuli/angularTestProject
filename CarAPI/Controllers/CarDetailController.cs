using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAPI.Models;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDetailController : ControllerBase
    {
        private readonly CarDetailContext _context;

        public CarDetailController(CarDetailContext context)
        {
            _context = context;
        }

        // GET: api/CarDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDetails>>> GetCarDetails()
        {
            return await _context.CarDetails.ToListAsync();
        }

        // GET: api/CarDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDetails>> GetCarDetails(int id)
        {
            var carDetails = await _context.CarDetails.FindAsync(id);

            if (carDetails == null)
            {
                return NotFound();
            }

            return carDetails;
        }

        // PUT: api/CarDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarDetails(int id, CarDetails carDetails)
        {
            if (id != carDetails.PMId)
            {
                return BadRequest();
            }

            _context.Entry(carDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarDetailsExists(id))
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

        // POST: api/CarDetail
        [HttpPost]
        public async Task<ActionResult<CarDetails>> PostCarDetails(CarDetails carDetails)
        {
            _context.CarDetails.Add(carDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarDetails", new { id = carDetails.PMId }, carDetails);
        }

        // DELETE: api/CarDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarDetails>> DeleteCarDetails(int id)
        {
            var carDetails = await _context.CarDetails.FindAsync(id);
            if (carDetails == null)
            {
                return NotFound();
            }

            _context.CarDetails.Remove(carDetails);
            await _context.SaveChangesAsync();

            return carDetails;
        }

        private bool CarDetailsExists(int id)
        {
            return _context.CarDetails.Any(e => e.PMId == id);
        }
    }
}
