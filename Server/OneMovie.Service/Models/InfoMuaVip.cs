using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneMovie.Service.Models
{
    public class InfoMuaVip
    {
        public String TaiKhoan { get; set; }

        public int IDGoi { get; set; }

        public DateTime? NgayMua { get; set; }

        public String TenGoi { get; set; }

        public int? ThoiGian { get; set; }

        public long? GiaTien { get; set; }

        public InfoMuaVip(string taiKhoan, int iDGoi, DateTime? ngayMua, string tenGoi, int? thoiGian, long? giaTien)
        {
            TaiKhoan = taiKhoan;
            IDGoi = iDGoi;
            NgayMua = ngayMua;
            TenGoi = tenGoi;
            ThoiGian = thoiGian;
            GiaTien = giaTien;
        }
    }
}
