﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Models
{
    public class Oder
    {
        public IEnumerable<DonHang> DonHangs { get; set; }
        public IEnumerable<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}