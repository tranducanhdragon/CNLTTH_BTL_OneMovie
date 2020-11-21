using System;
using System.Collections.Generic;

#nullable disable

namespace OneMovie.Service.Models
{
    public partial class PhanHoi
    {
        public string TaiKhoan { get; set; }
        public string NoiDung { get; set; }
        public DateTime? ThoiGian { get; set; }

        public virtual TaiKhoan TaiKhoanNavigation { get; set; }
    }
}
