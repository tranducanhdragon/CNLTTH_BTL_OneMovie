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
    public class QuocGiasController : ControllerBase
    {
        private readonly OneMovieContext _context;

        public QuocGiasController(OneMovieContext context)
        {
            _context = context;
        }

        // GET: api/QuocGias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuocGia>>> GetQuocGia()
        {
            return await _context.QuocGia.ToListAsync();
        }

        // GET: api/QuocGias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuocGia>> GetQuocGia(int id)
        {
            var quocGia = await _context.QuocGia.FindAsync(id);

            if (quocGia == null)
            {
                return NotFound();
            }

            return quocGia;
        }

        // PUT: api/QuocGias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuocGia(int id, QuocGia quocGia)
        {
            if (id != quocGia.MaQg)
            {
                return BadRequest();
            }

            _context.Entry(quocGia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuocGiaExists(id))
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

        // POST: api/QuocGias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<QuocGia>> PostQuocGia(QuocGia quocGia)
        {
            _context.QuocGia.Add(quocGia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuocGia", new { id = quocGia.MaQg }, quocGia);
        }

        // DELETE: api/QuocGias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuocGia>> DeleteQuocGia(int id)
        {
            var quocGia = await _context.QuocGia.FindAsync(id);
            if (quocGia == null)
            {
                return NotFound();
            }

            _context.QuocGia.Remove(quocGia);
            await _context.SaveChangesAsync();

            return quocGia;
        }

        private bool QuocGiaExists(int id)
        {
            return _context.QuocGia.Any(e => e.MaQg == id);
        }
    }
}
