using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngatlansController : ControllerBase
    {
        private readonly BackendContext _context;

        public IngatlansController(BackendContext context)
        {
            _context = context;
        }

        // GET: api/Ingatlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingatlan>>> GetIngatlan()
        {
          if (_context.Ingatlan == null)
          {
              return NotFound();
          }
            return await _context.Ingatlan.Include(x=>x.Kategoria).ToListAsync();
        }

        // GET: api/Ingatlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingatlan>> GetIngatlan(int id)
        {
          if (_context.Ingatlan == null)
          {
              return NotFound();
          }
            var ingatlan = await _context.Ingatlan.Where(x=>x.Id==id).Include(x=>x.Kategoria).FirstOrDefaultAsync();

            if (ingatlan == null)
            {
                return NotFound();
            }

            return ingatlan;
        }

        // PUT: api/Ingatlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngatlan(int id, Ingatlan ingatlan)
        {
            if (id != ingatlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingatlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngatlanExists(id))
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

        // POST: api/Ingatlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingatlan>> PostIngatlan(Ingatlan ingatlan)
        {
          if (_context.Ingatlan == null)
          {
                return BadRequest("Hiányos adatok");
            }
            _context.Ingatlan.Add(ingatlan);
            await _context.SaveChangesAsync();

            return StatusCode(201, new
            {
                ingatlan.Id
            });
        }

        // DELETE: api/Ingatlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngatlan(int id)
        {
            if (_context.Ingatlan == null)
            {
                return NotFound();
            }
            var ingatlan = await _context.Ingatlan.FindAsync(id);
            if (ingatlan == null)
            {
                return NotFound("Az ingatlan nem létezik");
            }

            _context.Ingatlan.Remove(ingatlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngatlanExists(int id)
        {
            return (_context.Ingatlan?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
