using System;
using System.Collections.Generic;

#nullable disable

namespace OneMovie.Service.Models
{
    public partial class NsxBoPhim
    {
        public int MaNsx { get; set; }
        public int MaBp { get; set; }

        public virtual BoPhim MaBpNavigation { get; set; }
        public virtual Nsx MaNsxNavigation { get; set; }
    }
}
