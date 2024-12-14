using DTO;
using System;
using System.Linq;

namespace DAL
{
    public class KhoHang_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm kho hàng
        public void ThemKhoHang(KhoHang khoHang)
        {
            var newKhoHang = new KhoHang
            {
                MaSanPham = khoHang.MaSanPham,
                SoLuongTrongKho = khoHang.SoLuongTrongKho
            };
            ql.KhoHangs.InsertOnSubmit(newKhoHang);
            ql.SubmitChanges();
        }

        // Sửa thông tin kho hàng
        public void SuaKhoHang(KhoHang khoHang)
        {
            var existingKhoHang = ql.KhoHangs.SingleOrDefault(k => k.MaSanPham == khoHang.MaSanPham);
            if (existingKhoHang != null)
            {
                existingKhoHang.SoLuongTrongKho = khoHang.SoLuongTrongKho;
                ql.SubmitChanges();
            }
        }

        // Xóa kho hàng
        public void XoaKhoHang(int maSanPham)
        {
            var khoHang = ql.KhoHangs.SingleOrDefault(k => k.MaSanPham == maSanPham);
            if (khoHang != null)
            {
                ql.KhoHangs.DeleteOnSubmit(khoHang);
                ql.SubmitChanges();
            }
        }

        // Lấy thông tin kho hàng theo MaSanPham
        public KhoHang LayKhoHangTheoMaSanPham(int maSanPham)
        {
            return ql.KhoHangs.SingleOrDefault(k => k.MaSanPham == maSanPham);
        }

        // Kiểm tra kho hàng tồn tại
        public bool KhoHangTonTai(int maSanPham)
        {
            return ql.KhoHangs.Any(k => k.MaSanPham == maSanPham);
        }
    }
}
