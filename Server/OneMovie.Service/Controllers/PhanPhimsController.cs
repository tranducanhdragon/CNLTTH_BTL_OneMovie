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
    public class PhanPhimsController : ControllerBase
    {
        private readonly OneMovieContext _context;

        public PhanPhimsController(OneMovieContext context)
        {
            _context = context;
        }

        // GET: api/PhanPhims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhanPhim>>> GetPhanPhims()
        {
            return await _context.PhanPhims.ToListAsync();
        }

        // GET: api/PhanPhims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhanPhim>> GetPhanPhim(string id)
        {
            var phanPhim = await _context.PhanPhims.FindAsync(id);

            if (phanPhim == null)
            {
                return NotFound();
            }

            return phanPhim;
        }

        // PUT: api/PhanPhims/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhanPhim(string id, PhanPhim phanPhim)
        {
            if (id != phanPhim.MaPhim)
            {
                return BadRequest();
            }

            _context.Entry(phanPhim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhanPhimExists(id))
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

        // POST: api/PhanPhims
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PhanPhim>> PostPhanPhim(PhanPhim phanPhim)
        {
            _context.PhanPhims.Add(phanPhim);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhanPhimExists(phanPhim.MaPhim))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhanPhim", new { id = phanPhim.MaPhim }, phanPhim);
        }

        // DELETE: api/PhanPhims/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhanPhim>> DeletePhanPhim(string id)
        {
            var phanPhim = await _context.PhanPhims.FindAsync(id);
            if (phanPhim == null)
            {
                return NotFound();
            }

            _context.PhanPhims.Remove(phanPhim);
            await _context.SaveChangesAsync();

            return phanPhim;
        }

        private bool PhanPhimExists(string id)
        {
            return _context.PhanPhims.Any(e => e.MaPhim == id);
        }
    }
}
