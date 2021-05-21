using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimatesController : ControllerBase
    {
        private readonly ClimateContext _context;

        public ClimatesController(ClimateContext context)
        {
            _context = context;
        }

        // GET: api/Climates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Climate>>> Getclimates()
        {
            return await _context.climates.ToListAsync();
        }

        // GET: api/Climates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Climate>> GetClimate(int id)
        {
            var climate = await _context.climates.FindAsync(id);

            if (climate == null)
            {
                return NotFound();
            }

            return climate;
        }

        // PUT: api/Climates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClimate(int id, Climate climate)
        {
            if (id != climate.Id)
            {
                return BadRequest();
            }

            _context.Entry(climate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClimateExists(id))
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

        // POST: api/Climates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Climate>> PostClimate(Climate climate)
        {
            _context.climates.Add(climate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClimate", new { id = climate.Id }, climate);
        }

        // DELETE: api/Climates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClimate(int id)
        {
            var climate = await _context.climates.FindAsync(id);
            if (climate == null)
            {
                return NotFound();
            }

            _context.climates.Remove(climate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClimateExists(int id)
        {
            return _context.climates.Any(e => e.Id == id);
        }


    }
}
