using DTO;
using DAL;
using System;
using System.Linq;

namespace BLL
{
    public class PhieuNhapHang_BLL
    {
        private PhieuNhapHang_DAL phieuNhapHangDAL;

        public PhieuNhapHang_BLL()
        {
            phieuNhapHangDAL = new PhieuNhapHang_DAL();
        }

        // Thêm phiếu nhập hàng
        public void ThemPhieuNhapHang(PhieuNhapHang phieuNhapHang)
        {
            phieuNhapHangDAL.ThemPhieuNhapHang(phieuNhapHang);
        }

        // Sửa phiếu nhập hàng
        public void SuaPhieuNhapHang(PhieuNhapHang phieuNhapHang)
        {
            phieuNhapHangDAL.SuaPhieuNhapHang(phieuNhapHang);
        }

        // Xóa phiếu nhập hàng
        public void XoaPhieuNhapHang(int maPhieuNhap)
        {
            phieuNhapHangDAL.XoaPhieuNhapHang(maPhieuNhap);
        }

        // Lấy thông tin phiếu nhập hàng theo MaPhieuNhap
        public PhieuNhapHang LayPhieuNhapHangTheoMa(int maPhieuNhap)
        {
            return phieuNhapHangDAL.LayPhieuNhapHangTheoMa(maPhieuNhap);
        }

        // Kiểm tra phiếu nhập hàng tồn tại theo MaPhieuNhap
        public bool PhieuNhapHangTonTai(int maPhieuNhap)
        {
            return phieuNhapHangDAL.PhieuNhapHangTonTai(maPhieuNhap);
        }

        // Lấy tất cả phiếu nhập hàng
        public IQueryable<PhieuNhapHang> LayTatCaPhieuNhapHang()
        {
            return phieuNhapHangDAL.LayTatCaPhieuNhapHang();
        }
    }
}
