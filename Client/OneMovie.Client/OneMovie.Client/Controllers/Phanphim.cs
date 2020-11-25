using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneMovie.Client.Controllers
{
    public class Phanphim
    {
        public string MaPhim { get; set; }
        public string TenPhim { get; set; }
        public string ThoiLuong { get; set; }
        public int? Tap { get; set; }
        public DateTime? NamXb { get; set; }
        public int? DanhGia { get; set; }
        public long? LuotXem { get; set; }
        public string LinkAnh { get; set; }
        public int? PhimVip { get; set; }
        public int? MaBp { get; set; }
    }
}