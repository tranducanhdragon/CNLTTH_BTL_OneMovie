using System;
using System.Collections.Generic;

#nullable disable

namespace OneMovie.Service.Models
{
    public partial class QuocGiaBoPhim
    {
        public int? MaQg { get; set; }
        public int MaBp { get; set; }

        public virtual BoPhim MaBpNavigation { get; set; }
        public virtual QuocGia MaQgNavigation { get; set; }
    }
}
