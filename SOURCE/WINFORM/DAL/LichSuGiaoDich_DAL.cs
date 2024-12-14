using DTO;
using System;
using System.Linq;

namespace DAL
{
    public class LichSuGiaoDich_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm lịch sử giao dịch
        public void ThemLichSuGiaoDich(LichSuGiaoDich lichSuGiaoDich)
        {
            var newLichSuGiaoDich = new LichSuGiaoDich
            {
                MaDonHang = lichSuGiaoDich.MaDonHang,
                TrangThai = lichSuGiaoDich.TrangThai,
                NgayCapNhat = lichSuGiaoDich.NgayCapNhat
            };
            ql.LichSuGiaoDiches.InsertOnSubmit(newLichSuGiaoDich);
            ql.SubmitChanges();
        }

        // Sửa lịch sử giao dịch
        public void SuaLichSuGiaoDich(LichSuGiaoDich lichSuGiaoDich)
        {
            var existingLichSuGiaoDich = ql.LichSuGiaoDiches.SingleOrDefault(ls => ls.MaLichSu == lichSuGiaoDich.MaLichSu);
            if (existingLichSuGiaoDich != null)
            {
                existingLichSuGiaoDich.MaDonHang = lichSuGiaoDich.MaDonHang;
                existingLichSuGiaoDich.TrangThai = lichSuGiaoDich.TrangThai;
                existingLichSuGiaoDich.NgayCapNhat = lichSuGiaoDich.NgayCapNhat;
                ql.SubmitChanges();
            }
        }

        // Xóa lịch sử giao dịch
        public void XoaLichSuGiaoDich(int maLichSu)
        {
            var lichSuGiaoDich = ql.LichSuGiaoDiches.SingleOrDefault(ls => ls.MaLichSu == maLichSu);
            if (lichSuGiaoDich != null)
            {
                ql.LichSuGiaoDiches.DeleteOnSubmit(lichSuGiaoDich);
                ql.SubmitChanges();
            }
        }

        // Lấy lịch sử giao dịch theo MaLichSu
        public LichSuGiaoDich LayLichSuGiaoDichTheoMa(int maLichSu)
        {
            return ql.LichSuGiaoDiches.SingleOrDefault(ls => ls.MaLichSu == maLichSu);
        }

        // Kiểm tra lịch sử giao dịch tồn tại theo MaLichSu
        public bool LichSuGiaoDichTonTai(int maLichSu)
        {
            return ql.LichSuGiaoDiches.Any(ls => ls.MaLichSu == maLichSu);
        }

        // Lấy tất cả lịch sử giao dịch
        public IQueryable<LichSuGiaoDich> LayTatCaLichSuGiaoDich()
        {
            return ql.LichSuGiaoDiches;
        }
    }
}
