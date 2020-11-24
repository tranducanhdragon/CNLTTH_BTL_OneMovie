using System;
using System.Collections.Generic;

#nullable disable

namespace OneMovie.Service.Models
{
    public partial class MuaVip
    {
        public string TaiKhoan { get; set; }
        public int Idgoi { get; set; }
        public DateTime? NgayMua { get; set; }

        public virtual GoiVip IdgoiNavigation { get; set; }
        public virtual TaiKhoan TaiKhoanNavigation { get; set; }
    }
}
