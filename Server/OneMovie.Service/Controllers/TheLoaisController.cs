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
    public class TheLoaisController : ControllerBase
    {
        private readonly OneMovieContext _context;

        public TheLoaisController(OneMovieContext context)
        {
            _context = context;
        }

        // GET: api/TheLoais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheLoai>>> GetTheLoais()
        {
            return await _context.TheLoais.ToListAsync();
        }

        // GET: api/TheLoais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TheLoai>> GetTheLoai(int id)
        {
            var theLoai = await _context.TheLoais.FindAsync(id);

            if (theLoai == null)
            {
                return NotFound();
            }

            return theLoai;
        }

        // PUT: api/TheLoais/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheLoai(int id, TheLoai theLoai)
        {
            if (id != theLoai.MaTl)
            {
                return BadRequest();
            }

            _context.Entry(theLoai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheLoaiExists(id))
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

        // POST: api/TheLoais
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TheLoai>> PostTheLoai(TheLoai theLoai)
        {
            _context.TheLoais.Add(theLoai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTheLoai", new { id = theLoai.MaTl }, theLoai);
        }

        // DELETE: api/TheLoais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TheLoai>> DeleteTheLoai(int id)
        {
            var theLoai = await _context.TheLoais.FindAsync(id);
            if (theLoai == null)
            {
                return NotFound();
            }

            _context.TheLoais.Remove(theLoai);
            await _context.SaveChangesAsync();

            return theLoai;
        }

        private bool TheLoaiExists(int id)
        {
            return _context.TheLoais.Any(e => e.MaTl == id);
        }
    }
}
