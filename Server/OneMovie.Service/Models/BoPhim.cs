using System;
using System.Collections.Generic;

#nullable disable

namespace OneMovie.Service.Models
{
    public partial class BoPhim
    {
        public BoPhim()
        {
            PhanPhims = new HashSet<PhanPhim>();
        }

        public int MaBp { get; set; }
        public string TenBp { get; set; }
        public int? PhimBo { get; set; }
        public int? MaDd { get; set; }

        public virtual DaoDien MaDdNavigation { get; set; }
        public virtual ICollection<PhanPhim> PhanPhims { get; set; }
    }
}
