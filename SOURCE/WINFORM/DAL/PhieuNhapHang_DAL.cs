using DTO;
using System;
using System.Linq;

namespace DAL
{
    public class PhieuNhapHang_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm phiếu nhập hàng
        public void ThemPhieuNhapHang(PhieuNhapHang phieuNhapHang)
        {
            var newPhieuNhapHang = new PhieuNhapHang
            {
                MaNhaCungCap = phieuNhapHang.MaNhaCungCap,
                NgayNhap = phieuNhapHang.NgayNhap,
                TongTien = phieuNhapHang.TongTien,
                GhiChu = phieuNhapHang.GhiChu
            };
            ql.PhieuNhapHangs.InsertOnSubmit(newPhieuNhapHang);
            ql.SubmitChanges();
        }

        // Sửa phiếu nhập hàng
        public void SuaPhieuNhapHang(PhieuNhapHang phieuNhapHang)
        {
            var existingPhieuNhapHang = ql.PhieuNhapHangs.SingleOrDefault(pnh => pnh.MaPhieuNhap == phieuNhapHang.MaPhieuNhap);
            if (existingPhieuNhapHang != null)
            {
                existingPhieuNhapHang.MaNhaCungCap = phieuNhapHang.MaNhaCungCap;
                existingPhieuNhapHang.NgayNhap = phieuNhapHang.NgayNhap;
                existingPhieuNhapHang.TongTien = phieuNhapHang.TongTien;
                existingPhieuNhapHang.GhiChu = phieuNhapHang.GhiChu;
                ql.SubmitChanges();
            }
        }

        // Xóa phiếu nhập hàng
        public void XoaPhieuNhapHang(int maPhieuNhap)
        {
            var phieuNhapHang = ql.PhieuNhapHangs.SingleOrDefault(pnh => pnh.MaPhieuNhap == maPhieuNhap);
            if (phieuNhapHang != null)
            {
                ql.PhieuNhapHangs.DeleteOnSubmit(phieuNhapHang);
                ql.SubmitChanges();
            }
        }

        // Lấy thông tin phiếu nhập hàng theo MaPhieuNhap
        public PhieuNhapHang LayPhieuNhapHangTheoMa(int maPhieuNhap)
        {
            return ql.PhieuNhapHangs.SingleOrDefault(pnh => pnh.MaPhieuNhap == maPhieuNhap);
        }

        // Kiểm tra phiếu nhập hàng tồn tại theo MaPhieuNhap
        public bool PhieuNhapHangTonTai(int maPhieuNhap)
        {
            return ql.PhieuNhapHangs.Any(pnh => pnh.MaPhieuNhap == maPhieuNhap);
        }

        // Lấy tất cả phiếu nhập hàng
        public IQueryable<PhieuNhapHang> LayTatCaPhieuNhapHang()
        {
            return ql.PhieuNhapHangs;
        }
    }
}
