using DTO;
using DAL;
using System;

namespace BLL
{
    public class KhoHang_BLL
    {
        private KhoHang_DAL khoHangDAL;

        public KhoHang_BLL()
        {
            khoHangDAL = new KhoHang_DAL();
        }

        // Thêm kho hàng
        public void ThemKhoHang(KhoHang khoHang)
        {
            khoHangDAL.ThemKhoHang(khoHang);
        }

        // Sửa thông tin kho hàng
        public void SuaKhoHang(KhoHang khoHang)
        {
            khoHangDAL.SuaKhoHang(khoHang);
        }

        // Xóa kho hàng
        public void XoaKhoHang(int maSanPham)
        {
            khoHangDAL.XoaKhoHang(maSanPham);
        }

        // Lấy thông tin kho hàng theo MaSanPham
        public KhoHang LayKhoHangTheoMaSanPham(int maSanPham)
        {
            return khoHangDAL.LayKhoHangTheoMaSanPham(maSanPham);
        }

        // Kiểm tra kho hàng tồn tại
        public bool KhoHangTonTai(int maSanPham)
        {
            return khoHangDAL.KhoHangTonTai(maSanPham);
        }
    }
}
