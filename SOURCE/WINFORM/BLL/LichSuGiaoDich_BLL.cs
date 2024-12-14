using DTO;
using DAL;
using System;
using System.Linq;

namespace BLL
{
    public class LichSuGiaoDich_BLL
    {
        private LichSuGiaoDich_DAL lichSuGiaoDichDAL;

        public LichSuGiaoDich_BLL()
        {
            lichSuGiaoDichDAL = new LichSuGiaoDich_DAL();
        }

        // Thêm lịch sử giao dịch
        public void ThemLichSuGiaoDich(LichSuGiaoDich lichSuGiaoDich)
        {
            lichSuGiaoDichDAL.ThemLichSuGiaoDich(lichSuGiaoDich);
        }

        // Sửa lịch sử giao dịch
        public void SuaLichSuGiaoDich(LichSuGiaoDich lichSuGiaoDich)
        {
            lichSuGiaoDichDAL.SuaLichSuGiaoDich(lichSuGiaoDich);
        }

        // Xóa lịch sử giao dịch
        public void XoaLichSuGiaoDich(int maLichSu)
        {
            lichSuGiaoDichDAL.XoaLichSuGiaoDich(maLichSu);
        }

        // Lấy lịch sử giao dịch theo MaLichSu
        public LichSuGiaoDich LayLichSuGiaoDichTheoMa(int maLichSu)
        {
            return lichSuGiaoDichDAL.LayLichSuGiaoDichTheoMa(maLichSu);
        }

        // Kiểm tra lịch sử giao dịch tồn tại theo MaLichSu
        public bool LichSuGiaoDichTonTai(int maLichSu)
        {
            return lichSuGiaoDichDAL.LichSuGiaoDichTonTai(maLichSu);
        }

        // Lấy tất cả lịch sử giao dịch
        public IQueryable<LichSuGiaoDich> LayTatCaLichSuGiaoDich()
        {
            return lichSuGiaoDichDAL.LayTatCaLichSuGiaoDich();
        }
    }
}
