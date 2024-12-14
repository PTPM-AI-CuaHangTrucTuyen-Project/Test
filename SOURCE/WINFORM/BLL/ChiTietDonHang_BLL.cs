using DTO;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ChiTietDonHang_BLL
    {
        private ChiTietDonHang_DAL chiTietDonHangDAL;

        public ChiTietDonHang_BLL()
        {
            chiTietDonHangDAL = new ChiTietDonHang_DAL();
        }

        // Thêm chi tiết đơn hàng
        public void ThemChiTietDonHang(ChiTietDonHang chiTietDonHang)
        {
            chiTietDonHangDAL.ThemChiTietDonHang(chiTietDonHang);
        }

        // Sửa thông tin chi tiết đơn hàng
        public void SuaChiTietDonHang(ChiTietDonHang chiTietDonHang)
        {
            chiTietDonHangDAL.SuaChiTietDonHang(chiTietDonHang);
        }

        // Xóa chi tiết đơn hàng
        public void XoaChiTietDonHang(int maChiTiet)
        {
            chiTietDonHangDAL.XoaChiTietDonHang(maChiTiet);
        }

        // Lấy tất cả chi tiết đơn hàng
        public List<ChiTietDonHang> LayTatCaChiTietDonHang()
        {
            return chiTietDonHangDAL.LayTatCaChiTietDonHang();
        }

        // Lấy chi tiết đơn hàng theo MaDonHang
        public List<ChiTietDonHang> LayChiTietDonHangTheoMaDonHang(int maDonHang)
        {
            return chiTietDonHangDAL.LayChiTietDonHangTheoMaDonHang(maDonHang);
        }

        // Lấy chi tiết đơn hàng theo MaChiTiet
        public ChiTietDonHang LayChiTietDonHangTheoID(int maChiTiet)
        {
            return chiTietDonHangDAL.LayChiTietDonHangTheoID(maChiTiet);
        }
    }
}
