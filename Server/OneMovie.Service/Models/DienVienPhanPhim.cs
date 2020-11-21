using System;
using System.Collections.Generic;

#nullable disable

namespace OneMovie.Service.Models
{
    public partial class DienVienPhanPhim
    {
        public int MaDv { get; set; }
        public string MaPp { get; set; }

        public virtual DienVien MaDvNavigation { get; set; }
        public virtual PhanPhim MaPpNavigation { get; set; }
    }
}
