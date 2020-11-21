using System;
using System.Collections.Generic;

#nullable disable

namespace OneMovie.Service.Models
{
    public partial class DaoDien
    {
        public DaoDien()
        {
            BoPhims = new HashSet<BoPhim>();
        }

        public int MaDd { get; set; }
        public string TenDd { get; set; }

        public virtual ICollection<BoPhim> BoPhims { get; set; }
    }
}
