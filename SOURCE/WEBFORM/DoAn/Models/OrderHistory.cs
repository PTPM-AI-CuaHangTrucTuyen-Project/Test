using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Models
{
    public class OrderHistory
    {
        public int MaDonHang { get; set; }
        public DateTime NgayDatHang { get; set; }
        public string NgayGiaoHang { get; set; }
        public string DaThanhToan { get; set; }
        public bool TinhTrangGiaoHang { get; set; }
        public List<OrderDetails> ChiTietDonHangs { get; set; }

    }
}