using DTO;
using DAL;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BLL
{
    public class BangTichDiem_BLL
    {
        private BangTichDiem_DAL bangTichDiemDAL;

        public BangTichDiem_BLL()
        {
            bangTichDiemDAL = new BangTichDiem_DAL();
        }

        // Thêm bản ghi tích điểm
        public void ThemBangTichDiem(BangTichDiem bangTichDiem)
        {
            bangTichDiemDAL.ThemBangTichDiem(bangTichDiem);
        }

        // Sửa bản ghi tích điểm
        public void SuaBangTichDiem(BangTichDiem bangTichDiem)
        {
            bangTichDiemDAL.SuaBangTichDiem(bangTichDiem);
        }

        // Xóa bản ghi tích điểm
        public void XoaBangTichDiem(int maTichDiem)
        {
            bangTichDiemDAL.XoaBangTichDiem(maTichDiem);
        }

        // Lấy bản ghi tích điểm theo MaTichDiem
        public BangTichDiem LayBangTichDiemTheoMa(int maTichDiem)
        {
            return bangTichDiemDAL.LayBangTichDiemTheoMa(maTichDiem);
        }

        // Kiểm tra bản ghi tích điểm tồn tại theo MaKhachHang
        public bool BangTichDiemTonTai(int maKhachHang)
        {
            return bangTichDiemDAL.BangTichDiemTonTai(maKhachHang);
        }

        // Lấy tất cả bản ghi tích điểm
        public List<BangTichDiem> LayTatCaBangTichDiem()
        {
            return bangTichDiemDAL.LayTatCaBangTichDiem();
        }
    }
}
