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
    public class TaiKhoansController : ControllerBase
    {
        private readonly OneMovieContext _context;

        public TaiKhoansController(OneMovieContext context)
        {
            _context = context;
        }

        // GET: api/TaiKhoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiKhoan>>> GetTaiKhoans()
        {
            return await _context.TaiKhoans.ToListAsync();
        }

        // GET: api/TaiKhoans/5
        [HttpGet]
        [Route("{taikhoan}/{matkhau}")]
        public ServiceRespone GetTaiKhoan(string taikhoan,string matkhau)
        {
            ServiceRespone res = new ServiceRespone();

            var taiKhoanDB =  _context.TaiKhoans.Where(s => s.TaiKhoan1 == taikhoan && s.MatKhau == matkhau).FirstOrDefault();

            if (taiKhoanDB == null)
            {
                res.Message = "Sai tên đăng nhập hoặc mật khẩu";
                res.Success = false;
                return res;
            }
            if(taiKhoanDB.LoaiTk == 1)
            {
                res.Success = true;
                res.Type = 1;
                res.Data = taiKhoanDB;
            }
            else
            {

                res.Success = true;
                res.Type = 0;
                res.Data = taiKhoanDB;
            }
            return res;
        }

        // PUT: api/TaiKhoans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaiKhoan(string id, TaiKhoan taiKhoan)
        {
            if (id != taiKhoan.TaiKhoan1)
            {
                return BadRequest();
            }

            _context.Entry(taiKhoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiKhoanExists(id))
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

        // POST: api/TaiKhoans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ServiceRespone> PostTaiKhoan(TaiKhoan taiKhoan)

        {
            ServiceRespone res = new ServiceRespone();
            if (taiKhoan.TaiKhoan1.Trim() == "" || taiKhoan.MatKhau.Trim() == "")
            {
                res.Message = "Vui lòng nhập các trường bắt buộc";
                res.Success = false;
                return res;
            }

            var taikhoanDB = _context.TaiKhoans.FirstOrDefault(x => x.TaiKhoan1 == taiKhoan.TaiKhoan1);
            if(taikhoanDB != null)
            {
                res.Message = "Tên đăng nhập này đã được sử dụng";
                res.Success = false;
                res.ErrorCode = 1;
                return res;
            }

            taiKhoan.LoaiTk = 0;
            _context.TaiKhoans.Add(taiKhoan);
            await _context.SaveChangesAsync();
            res.Success = true;
            return res;
        }

        // DELETE: api/TaiKhoans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaiKhoan>> DeleteTaiKhoan(string id)
        {
            var taiKhoan = await _context.TaiKhoans.FindAsync(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            _context.TaiKhoans.Remove(taiKhoan);
            await _context.SaveChangesAsync();

            return taiKhoan;
        }

        private bool TaiKhoanExists(string id)
        {
            return _context.TaiKhoans.Any(e => e.TaiKhoan1 == id);
        }
    }
}
