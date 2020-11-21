using System;
using System.Collections.Generic;

#nullable disable

namespace OneMovie.Service.Models
{
    public partial class TaiKhoan
    {
        public string TaiKhoan1 { get; set; }
        public string MatKhau { get; set; }
        public int? LoaiTk { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Sdt { get; set; }

        public virtual BinhLuan BinhLuan { get; set; }
        public virtual DanhGium DanhGium { get; set; }
        public virtual LichSuXem LichSuXem { get; set; }
        public virtual LuuPhim LuuPhim { get; set; }
        public virtual MuaVip MuaVip { get; set; }
        public virtual PhanHoi PhanHoi { get; set; }
    }
}
