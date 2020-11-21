using System;
using System.Collections.Generic;

#nullable disable

namespace OneMovie.Service.Models
{
    public partial class LuuPhim
    {
        public string TaiKhoan { get; set; }
        public string MaPhim { get; set; }
        public DateTime? ThoiGian { get; set; }

        public virtual PhanPhim MaPhimNavigation { get; set; }
        public virtual TaiKhoan TaiKhoanNavigation { get; set; }
    }
}
