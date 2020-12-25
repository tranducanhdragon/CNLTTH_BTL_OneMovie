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
    public class MuaVipsController : ControllerBase
    {
        private readonly OneMovieContext _context;

        public MuaVipsController(OneMovieContext context)
        {
            _context = context;
        }

        // GET: api/MuaVips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MuaVip>>> GetMuaVips()
        {
            List<MuaVip> muavips = _context.MuaVips.ToList();
            return await _context.MuaVips.ToListAsync();
        }

        [Route("/api/GetInfoMuaVip")]
        public List<InfoMuaVip> GetInfoMuaVip()
        {
            List<InfoMuaVip> infoMuaVips = new List<InfoMuaVip>();
            var query = from MuaVip in _context.MuaVips join GoiVip in _context.GoiVips on MuaVip.Idgoi equals GoiVip.Idgoi select new { MuaVip,GoiVip } ;
            foreach(var item in query)
            {
                infoMuaVips.Add(new InfoMuaVip(item.MuaVip.TaiKhoan,item.MuaVip.Idgoi,item.MuaVip.NgayMua,item.GoiVip.TenGoi,item.GoiVip.ThoiGian,item.GoiVip.GiaTien));
            }
            return infoMuaVips;
        }

        // GET: api/MuaVips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MuaVip>> GetMuaVip(string id)
        {
            var muaVip = await _context.MuaVips.FindAsync(id);

            if (muaVip == null)
            {
                return NotFound();
            }

            return muaVip;
        }

        // PUT: api/MuaVips/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuaVip(string id, MuaVip muaVip)
        {
            if (id != muaVip.TaiKhoan)
            {
                return BadRequest();
            }

            _context.Entry(muaVip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuaVipExists(id))
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

        // POST: api/MuaVips
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ServiceRespone> PostMuaVip(MuaVip muaVip)
        {
            ServiceRespone res = new ServiceRespone();
            muaVip.NgayMua = DateTime.Now;
            _context.MuaVips.Add(muaVip);
            res.Success = true;
            res.Message = "Đã Đăng Ký Gói!";
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MuaVipExists(muaVip.TaiKhoan))
                {
                    res.Message = "Tài khoản nạp thêm hạn";
                }
                else
                {
                    res.Message = "Có lỗi!";
                    res.Success = false;
                    throw;
                }
            }

            return res;
        }

        // DELETE: api/MuaVips/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MuaVip>> DeleteMuaVip(string id)
        {
            var muaVip = await _context.MuaVips.FindAsync(id);
            if (muaVip == null)
            {
                return NotFound();
            }

            _context.MuaVips.Remove(muaVip);
            await _context.SaveChangesAsync();

            return muaVip;
        }

        private bool MuaVipExists(string id)
        {
            return _context.MuaVips.Any(e => e.TaiKhoan == id);
        }
    }
}
