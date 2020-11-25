using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneMovie.Client.Models
{
    public class Taikhoan
    {
        public string TaiKhoan1 { get; set; }
        public string MatKhau { get; set; }
        public int? LoaiTk { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Sdt { get; set; }
    }
}