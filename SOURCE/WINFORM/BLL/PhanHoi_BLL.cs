using DTO;
using DAL;
using System;
using System.Linq;

namespace BLL
{
    public class PhanHoi_BLL
    {
        private PhanHoi_DAL phanHoiDAL;

        public PhanHoi_BLL()
        {
            phanHoiDAL = new PhanHoi_DAL();
        }

        // Thêm phản hồi
        public void ThemPhanHoi(PhanHoi phanHoi)
        {
            phanHoiDAL.ThemPhanHoi(phanHoi);
        }

        // Sửa phản hồi
        public void SuaPhanHoi(PhanHoi phanHoi)
        {
            phanHoiDAL.SuaPhanHoi(phanHoi);
        }

        // Xóa phản hồi
        public void XoaPhanHoi(int maPhanHoi)
        {
            phanHoiDAL.XoaPhanHoi(maPhanHoi);
        }

        // Lấy phản hồi theo MaPhanHoi
        public PhanHoi LayPhanHoiTheoMa(int maPhanHoi)
        {
            return phanHoiDAL.LayPhanHoiTheoMa(maPhanHoi);
        }

        // Kiểm tra phản hồi tồn tại theo MaPhanHoi
        public bool PhanHoiTonTai(int maPhanHoi)
        {
            return phanHoiDAL.PhanHoiTonTai(maPhanHoi);
        }

        // Lấy tất cả phản hồi
        public IQueryable<PhanHoi> LayTatCaPhanHoi()
        {
            return phanHoiDAL.LayTatCaPhanHoi();
        }
    }
}
