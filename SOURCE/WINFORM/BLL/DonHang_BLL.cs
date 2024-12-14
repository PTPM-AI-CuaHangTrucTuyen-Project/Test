using DAL;
using DTO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class DonHang_BLL
    {
        private DonHang_DAL donHangDAL = new DonHang_DAL();

        public void ThemDonHang(DonHang donHang) => donHangDAL.ThemDonHang(donHang);

        public void SuaDonHang(DonHang donHang) => donHangDAL.SuaDonHang(donHang);

        public void XoaDonHang(int maDonHang) => donHangDAL.XoaDonHang(maDonHang);

        public List<DonHang> LayTatCaDonHang() => donHangDAL.LayTatCaDonHang();

        public List<DonHang> LayDonHangTheoLoc(string daThanhToan = "", bool? tinhTrangGiaoHang = null, DateTime? Ngay = null)
            => donHangDAL.LayDonHangTheoLoc(daThanhToan, tinhTrangGiaoHang, Ngay);

        public List<KhachHang> LayTatCaKhachHang() => donHangDAL.LayTatCaKhachHang();

        public List<DonHang> TimKiemDonHangTheoTenKhachHang(string tenKhachHang)
            => donHangDAL.TimKiemDonHangTheoTenKhachHang(tenKhachHang);
    }
}
