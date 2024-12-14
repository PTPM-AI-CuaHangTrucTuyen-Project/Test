using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ChiTietDonHang_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm chi tiết đơn hàng
        public void ThemChiTietDonHang(ChiTietDonHang chiTietDonHang)
        {
            var newChiTiet = new ChiTietDonHang
            {
                MaDonHang = chiTietDonHang.MaDonHang,
                MaSanPham = chiTietDonHang.MaSanPham,
                TenSanPham = chiTietDonHang.TenSanPham,
                HinhAnh = chiTietDonHang.HinhAnh,
                SoLuong = chiTietDonHang.SoLuong,
                GiaBan = chiTietDonHang.GiaBan
            };
            ql.ChiTietDonHangs.InsertOnSubmit(newChiTiet);
            ql.SubmitChanges();
        }

        // Sửa thông tin chi tiết đơn hàng
        public void SuaChiTietDonHang(ChiTietDonHang chiTietDonHang)
        {
            var existingChiTiet = ql.ChiTietDonHangs.SingleOrDefault(c => c.MaChiTiet == chiTietDonHang.MaChiTiet);
            if (existingChiTiet != null)
            {
                existingChiTiet.MaDonHang = chiTietDonHang.MaDonHang;
                existingChiTiet.MaSanPham = chiTietDonHang.MaSanPham;
                existingChiTiet.TenSanPham = chiTietDonHang.TenSanPham;
                existingChiTiet.HinhAnh = chiTietDonHang.HinhAnh;
                existingChiTiet.SoLuong = chiTietDonHang.SoLuong;
                existingChiTiet.GiaBan = chiTietDonHang.GiaBan;
                ql.SubmitChanges();
            }
        }

        // Xóa chi tiết đơn hàng
        public void XoaChiTietDonHang(int maChiTiet)
        {
            var chiTiet = ql.ChiTietDonHangs.SingleOrDefault(c => c.MaChiTiet == maChiTiet);
            if (chiTiet != null)
            {
                ql.ChiTietDonHangs.DeleteOnSubmit(chiTiet);
                ql.SubmitChanges();
            }
        }

        // Lấy tất cả chi tiết đơn hàng
        public List<ChiTietDonHang> LayTatCaChiTietDonHang()
        {
            return ql.ChiTietDonHangs.ToList();
        }

        // Lấy chi tiết đơn hàng theo MaDonHang
        public List<ChiTietDonHang> LayChiTietDonHangTheoMaDonHang(int maDonHang)
        {
            return ql.ChiTietDonHangs.Where(c => c.MaDonHang == maDonHang).ToList();
        }

        // Lấy chi tiết đơn hàng theo MaChiTiet
        public ChiTietDonHang LayChiTietDonHangTheoID(int maChiTiet)
        {
            return ql.ChiTietDonHangs.SingleOrDefault(c => c.MaChiTiet == maChiTiet);
        }
    }
}
