using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiftLogger.Data;
using ShiftLogger.Models;

namespace ShiftLogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class shiftController : ControllerBase
    {
        private readonly shiftLoggerContext _context;

        public shiftController(shiftLoggerContext context)
        {
            _context = context;
        }

        // GET: api/shift
        [HttpGet]
        public async Task<ActionResult<IEnumerable<shiftLogger>>> GetItems()
        {
          if (_context.Items == null)
          {
              return NotFound();
          }
            return await _context.Items.ToListAsync();
        }

        // GET: api/shift/5
        [HttpGet("{id}")]
        public async Task<ActionResult<shiftLogger>> GetshiftLogger(int id)
        {
          if (_context.Items == null)
          {
              return NotFound();
          }
            var shiftLogger = await _context.Items.FindAsync(id);

            if (shiftLogger == null)
            {
                return NotFound();
            }

            return shiftLogger;
        }

        // PUT: api/shift/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutshiftLogger(int id, shiftLogger shiftLogger)
        {
            if (id != shiftLogger.Id)
            {
                return BadRequest();
            }

            _context.Entry(shiftLogger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!shiftLoggerExists(id))
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

        // POST: api/shift
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<shiftLogger>> PostshiftLogger(shiftLogger shiftLogger)
        {
          if (_context.Items == null)
          {
              return Problem("Entity set 'shiftLoggerContext.Items'  is null.");
          }
            _context.Items.Add(shiftLogger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetshiftLogger", new { id = shiftLogger.Id }, shiftLogger);
        }

        // DELETE: api/shift/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteshiftLogger(int id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var shiftLogger = await _context.Items.FindAsync(id);
            if (shiftLogger == null)
            {
                return NotFound();
            }

            _context.Items.Remove(shiftLogger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool shiftLoggerExists(int id)
        {
            return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
