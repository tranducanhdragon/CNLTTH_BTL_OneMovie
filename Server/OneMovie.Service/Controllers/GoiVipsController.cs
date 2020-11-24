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
    public class GoiVipsController : ControllerBase
    {
        private readonly OneMovieContext _context;

        public GoiVipsController(OneMovieContext context)
        {
            _context = context;
        }

        // GET: api/GoiVips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoiVip>>> GetGoiVips()
        {
            return await _context.GoiVips.ToListAsync();
        }

        // GET: api/GoiVips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoiVip>> GetGoiVip(int id)
        {
            var goiVip = await _context.GoiVips.FindAsync(id);

            if (goiVip == null)
            {
                return NotFound();
            }

            return goiVip;
        }

        // PUT: api/GoiVips/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoiVip(int id, GoiVip goiVip)
        {
            if (id != goiVip.Idgoi)
            {
                return BadRequest();
            }

            _context.Entry(goiVip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoiVipExists(id))
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

        // POST: api/GoiVips
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GoiVip>> PostGoiVip(GoiVip goiVip)
        {
            _context.GoiVips.Add(goiVip);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GoiVipExists(goiVip.Idgoi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGoiVip", new { id = goiVip.Idgoi }, goiVip);
        }

        // DELETE: api/GoiVips/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GoiVip>> DeleteGoiVip(int id)
        {
            var goiVip = await _context.GoiVips.FindAsync(id);
            if (goiVip == null)
            {
                return NotFound();
            }

            _context.GoiVips.Remove(goiVip);
            await _context.SaveChangesAsync();

            return goiVip;
        }

        private bool GoiVipExists(int id)
        {
            return _context.GoiVips.Any(e => e.Idgoi == id);
        }
    }
}
