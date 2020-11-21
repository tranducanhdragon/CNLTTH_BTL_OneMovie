using System;
using System.Collections.Generic;

#nullable disable

namespace OneMovie.Service.Models
{
    public partial class BinhLuan
    {
        public string TaiKhoan { get; set; }
        public int? MaPhim { get; set; }
        public DateTime? ThoiGian { get; set; }
        public string NoiDung { get; set; }

        public virtual TaiKhoan TaiKhoanNavigation { get; set; }
    }
}
