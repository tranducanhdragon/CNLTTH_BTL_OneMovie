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
    public class LichSuXemsController : ControllerBase
    {
        private readonly OneMovieContext _context;

        public LichSuXemsController(OneMovieContext context)
        {
            _context = context;
        }

        // GET: api/LichSuXems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LichSuXem>>> GetLichSuXems()
        {
            return await _context.LichSuXems.ToListAsync();
        }

        // GET: api/LichSuXems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LichSuXem>> GetLichSuXem(string id)
        {
            var lichSuXem = await _context.LichSuXems.FindAsync(id);

            if (lichSuXem == null)
            {
                return NotFound();
            }

            return lichSuXem;
        }

        // PUT: api/LichSuXems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLichSuXem(string id, LichSuXem lichSuXem)
        {
            if (id != lichSuXem.TaiKhoan)
            {
                return BadRequest();
            }

            _context.Entry(lichSuXem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LichSuXemExists(id))
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

        // POST: api/LichSuXems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LichSuXem>> PostLichSuXem(LichSuXem lichSuXem)
        {
            _context.LichSuXems.Add(lichSuXem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LichSuXemExists(lichSuXem.TaiKhoan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLichSuXem", new { id = lichSuXem.TaiKhoan }, lichSuXem);
        }

        // DELETE: api/LichSuXems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LichSuXem>> DeleteLichSuXem(string id)
        {
            var lichSuXem = await _context.LichSuXems.FindAsync(id);
            if (lichSuXem == null)
            {
                return NotFound();
            }

            _context.LichSuXems.Remove(lichSuXem);
            await _context.SaveChangesAsync();

            return lichSuXem;
        }

        private bool LichSuXemExists(string id)
        {
            return _context.LichSuXems.Any(e => e.TaiKhoan == id);
        }
    }
}
