using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Areas.Admin.Models
{
    public class RevenueSummary
    {
        public DateTime Ngay { get; set; }
        public decimal TongTien { get; set; }
        public int SoLuongHoa { get; set; }
    }

}