using DTO;
using DAL;
using System;
using System.Linq;

namespace BLL
{
    public class ChiTietPhieuNhap_BLL
    {
        private ChiTietPhieuNhap_DAL chiTietPhieuNhapDAL;

        public ChiTietPhieuNhap_BLL()
        {
            chiTietPhieuNhapDAL = new ChiTietPhieuNhap_DAL();
        }

        // Thêm chi tiết phiếu nhập
        public void ThemChiTietPhieuNhap(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            chiTietPhieuNhapDAL.ThemChiTietPhieuNhap(chiTietPhieuNhap);
        }

        // Sửa chi tiết phiếu nhập
        public void SuaChiTietPhieuNhap(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            chiTietPhieuNhapDAL.SuaChiTietPhieuNhap(chiTietPhieuNhap);
        }

        // Xóa chi tiết phiếu nhập
        public void XoaChiTietPhieuNhap(int maChiTietPhieuNhap)
        {
            chiTietPhieuNhapDAL.XoaChiTietPhieuNhap(maChiTietPhieuNhap);
        }

        // Lấy chi tiết phiếu nhập theo MaChiTietPhieuNhap
        public ChiTietPhieuNhap LayChiTietPhieuNhapTheoMa(int maChiTietPhieuNhap)
        {
            return chiTietPhieuNhapDAL.LayChiTietPhieuNhapTheoMa(maChiTietPhieuNhap);
        }

        // Kiểm tra chi tiết phiếu nhập tồn tại theo MaChiTietPhieuNhap
        public bool ChiTietPhieuNhapTonTai(int maChiTietPhieuNhap)
        {
            return chiTietPhieuNhapDAL.ChiTietPhieuNhapTonTai(maChiTietPhieuNhap);
        }

        // Lấy tất cả chi tiết phiếu nhập
        public IQueryable<ChiTietPhieuNhap> LayTatCaChiTietPhieuNhap()
        {
            return chiTietPhieuNhapDAL.LayTatCaChiTietPhieuNhap();
        }
    }
}
