using System;
using System.Collections.Generic;

#nullable disable

namespace OneMovie.Service.Models
{
    public partial class GoiVip
    {
        public GoiVip()
        {
            MuaVips = new HashSet<MuaVip>();
        }

        public int Idgoi { get; set; }
        public string TenGoi { get; set; }
        public int? ThoiGian { get; set; }
        public long? GiaTien { get; set; }

        public virtual ICollection<MuaVip> MuaVips { get; set; }
    }
}
