using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneMovie.Service.Models;

namespace OneMovie.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaoDiensController : ControllerBase
    {
        private readonly OneMovieContext _context;

        public DaoDiensController(OneMovieContext context)
        {
            _context = context;
        }

        // GET: api/DaoDiens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DaoDien>>> GetDaoDiens()
        {
            return await _context.DaoDiens.ToListAsync();
        }

        // GET: api/DaoDiens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DaoDien>> GetDaoDien(int id)
        {
            var daoDien = await _context.DaoDiens.FindAsync(id);

            if (daoDien == null)
            {
                return NotFound();
            }

            return daoDien;
        }

        // PUT: api/DaoDiens/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDaoDien(int id, DaoDien daoDien)
        {
            if (id != daoDien.MaDd)
            {
                return BadRequest();
            }

            _context.Entry(daoDien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DaoDienExists(id))
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

        // POST: api/DaoDiens
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DaoDien>> PostDaoDien(DaoDien daoDien)
        {
            _context.DaoDiens.Add(daoDien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDaoDien", new { id = daoDien.MaDd }, daoDien);
        }

        // DELETE: api/DaoDiens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DaoDien>> DeleteDaoDien(int id)
        {
            var daoDien = await _context.DaoDiens.FindAsync(id);
            if (daoDien == null)
            {
                return NotFound();
            }

            _context.DaoDiens.Remove(daoDien);
            await _context.SaveChangesAsync();

            return daoDien;
        }

        private bool DaoDienExists(int id)
        {
            return _context.DaoDiens.Any(e => e.MaDd == id);
        }
    }
}
