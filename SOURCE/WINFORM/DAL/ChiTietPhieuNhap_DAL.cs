using DTO;
using System;
using System.Linq;

namespace DAL
{
    public class ChiTietPhieuNhap_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm chi tiết phiếu nhập
        public void ThemChiTietPhieuNhap(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            var newChiTietPhieuNhap = new ChiTietPhieuNhap
            {
                MaPhieuNhap = chiTietPhieuNhap.MaPhieuNhap,
                MaSanPham = chiTietPhieuNhap.MaSanPham,
                SoLuong = chiTietPhieuNhap.SoLuong,
                GiaNhap = chiTietPhieuNhap.GiaNhap
            };
            ql.ChiTietPhieuNhaps.InsertOnSubmit(newChiTietPhieuNhap);
            ql.SubmitChanges();
        }

        // Sửa chi tiết phiếu nhập
        public void SuaChiTietPhieuNhap(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            var existingChiTietPhieuNhap = ql.ChiTietPhieuNhaps.SingleOrDefault(ct => ct.MaChiTietPhieuNhap == chiTietPhieuNhap.MaChiTietPhieuNhap);
            if (existingChiTietPhieuNhap != null)
            {
                existingChiTietPhieuNhap.MaPhieuNhap = chiTietPhieuNhap.MaPhieuNhap;
                existingChiTietPhieuNhap.MaSanPham = chiTietPhieuNhap.MaSanPham;
                existingChiTietPhieuNhap.SoLuong = chiTietPhieuNhap.SoLuong;
                existingChiTietPhieuNhap.GiaNhap = chiTietPhieuNhap.GiaNhap;
                ql.SubmitChanges();
            }
        }

        // Xóa chi tiết phiếu nhập
        public void XoaChiTietPhieuNhap(int maChiTietPhieuNhap)
        {
            var chiTietPhieuNhap = ql.ChiTietPhieuNhaps.SingleOrDefault(ct => ct.MaChiTietPhieuNhap == maChiTietPhieuNhap);
            if (chiTietPhieuNhap != null)
            {
                ql.ChiTietPhieuNhaps.DeleteOnSubmit(chiTietPhieuNhap);
                ql.SubmitChanges();
            }
        }

        // Lấy chi tiết phiếu nhập theo MaChiTietPhieuNhap
        public ChiTietPhieuNhap LayChiTietPhieuNhapTheoMa(int maChiTietPhieuNhap)
        {
            return ql.ChiTietPhieuNhaps.SingleOrDefault(ct => ct.MaChiTietPhieuNhap == maChiTietPhieuNhap);
        }

        // Kiểm tra chi tiết phiếu nhập tồn tại theo MaChiTietPhieuNhap
        public bool ChiTietPhieuNhapTonTai(int maChiTietPhieuNhap)
        {
            return ql.ChiTietPhieuNhaps.Any(ct => ct.MaChiTietPhieuNhap == maChiTietPhieuNhap);
        }

        // Lấy tất cả chi tiết phiếu nhập
        public IQueryable<ChiTietPhieuNhap> LayTatCaChiTietPhieuNhap()
        {
            return ql.ChiTietPhieuNhaps;
        }
    }
}
