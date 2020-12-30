using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace OneMovie.Service.Models
{
    public partial class PhanPhim
    {
        public PhanPhim()
        {
            DanhGiaNavigation = new HashSet<DanhGia>();
            LichSuXems = new HashSet<LichSuXem>();
            LuuPhims = new HashSet<LuuPhim>();
        }

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
        public DateTime? NgayTao { get; set; }

        public virtual BoPhim MaBpNavigation { get; set; }
        public virtual ICollection<DanhGia> DanhGiaNavigation { get; set; }
        public virtual ICollection<LichSuXem> LichSuXems { get; set; }
        public virtual ICollection<LuuPhim> LuuPhims { get; set; }
    }
}
