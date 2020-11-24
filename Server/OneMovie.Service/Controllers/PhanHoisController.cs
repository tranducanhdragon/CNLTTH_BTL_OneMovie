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
    public class PhanHoisController : ControllerBase
    {
        private readonly OneMovieContext _context;

        public PhanHoisController(OneMovieContext context)
        {
            _context = context;
        }

        // GET: api/PhanHois
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhanHoi>>> GetPhanHois()
        {
            return await _context.PhanHois.ToListAsync();
        }

        // GET: api/PhanHois/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhanHoi>> GetPhanHoi(string id)
        {
            var phanHoi = await _context.PhanHois.FindAsync(id);

            if (phanHoi == null)
            {
                return NotFound();
            }

            return phanHoi;
        }

        // PUT: api/PhanHois/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhanHoi(string id, PhanHoi phanHoi)
        {
            if (id != phanHoi.TaiKhoan)
            {
                return BadRequest();
            }

            _context.Entry(phanHoi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhanHoiExists(id))
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

        // POST: api/PhanHois
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PhanHoi>> PostPhanHoi(PhanHoi phanHoi)
        {
            _context.PhanHois.Add(phanHoi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhanHoiExists(phanHoi.TaiKhoan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhanHoi", new { id = phanHoi.TaiKhoan }, phanHoi);
        }

        // DELETE: api/PhanHois/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhanHoi>> DeletePhanHoi(string id)
        {
            var phanHoi = await _context.PhanHois.FindAsync(id);
            if (phanHoi == null)
            {
                return NotFound();
            }

            _context.PhanHois.Remove(phanHoi);
            await _context.SaveChangesAsync();

            return phanHoi;
        }

        private bool PhanHoiExists(string id)
        {
            return _context.PhanHois.Any(e => e.TaiKhoan == id);
        }
    }
}
