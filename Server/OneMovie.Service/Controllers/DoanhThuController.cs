using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneMovie.Service.Models;

namespace OneMovie.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoanhThuController : ControllerBase
    {
        [HttpGet]
        public double GetDoanhThu()
        {
            double total=0;
            using(OneMovieContext db = new OneMovieContext())
            {
                var result = from e in db.MuaVips join e1 in db.GoiVips on e.Idgoi equals e1.Idgoi select new { e.Idgoi,e.NgayMua,e.TaiKhoan,e1.GiaTien };
                foreach(var item in result)
                {
                    total +=(double) item.GiaTien;
                }
            }

            return total;
        }
    }
}
