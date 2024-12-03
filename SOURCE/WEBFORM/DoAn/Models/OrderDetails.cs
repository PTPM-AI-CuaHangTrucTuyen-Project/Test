using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Models
{
    public class OrderDetails
    {
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaBan { get; set; }
    }
}