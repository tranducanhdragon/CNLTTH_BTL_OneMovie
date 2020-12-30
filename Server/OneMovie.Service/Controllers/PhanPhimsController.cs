using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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

        [HttpGet("GetByPaging")]
        public async Task<PagingData> GetDataByPagin([FromQuery] int page, [FromQuery] int record)
        {
            var pagingData = new PagingData();

            var allPhims = await _context.PhanPhims.OrderByDescending(_ => _.NgayTao).ToListAsync();
            pagingData.TotalRecord = allPhims.Count();
            pagingData.TotalPage = Convert.ToInt32(Math.Ceiling((decimal)pagingData.TotalRecord / (decimal)record));
            pagingData.Data = allPhims.Skip((page - 1) * record).Take(record).ToList();
            return pagingData;
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
        [Route("PosterFilm")]
        [HttpPost]
        public ServiceRespone PosterFilm(IFormFile files,[FromServices] IHostingEnvironment oHostingEnvironment)
        {
            ServiceRespone res = new ServiceRespone();
            if (files.Length > 0)
            {
                string url = $"{oHostingEnvironment.WebRootPath}\\Upload-img\\{files.FileName}";
                using (FileStream fileStream = System.IO.File.Create(url))
                {
                    files.CopyTo(fileStream);
                    fileStream.Flush();
                }
                res.Success = true;
                res.Data = files;
            }
            else
            {
                res.Success = false;
            }
            return res;
        }

        [Route("VideoFilm")]
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 4097152000)]
        [RequestSizeLimit(4097152000)]
        public ServiceRespone VideoFilm(IFormFile files, [FromServices] IHostingEnvironment oHostingEnvironment)
        {
            ServiceRespone res = new ServiceRespone();
            if (files.Length > 0)
            {
                string url = $"{oHostingEnvironment.WebRootPath}\\Upload-vid\\{files.FileName}";
                using (FileStream fileStream = System.IO.File.Create(url))
                {
                    files.CopyTo(fileStream);
                    fileStream.Flush();
                }
                res.Success = true;
                res.Data = files;
            }
            else
            {
                res.Success = false;
            }
            return res;
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
