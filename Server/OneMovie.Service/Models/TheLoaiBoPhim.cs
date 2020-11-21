using System;
using System.Collections.Generic;

#nullable disable

namespace OneMovie.Service.Models
{
    public partial class TheLoaiBoPhim
    {
        public int? MaTl { get; set; }
        public int MaBp { get; set; }

        public virtual BoPhim MaBpNavigation { get; set; }
        public virtual TheLoai MaTlNavigation { get; set; }
    }
}
