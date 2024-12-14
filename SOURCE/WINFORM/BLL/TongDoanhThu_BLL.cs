using DTO;
using DAL;
using System;
using System.Linq;

namespace BLL
{
    public class TongDoanhThu_BLL
    {
        private TongDoanhThu_DAL tongDoanhThuDAL;

        public TongDoanhThu_BLL()
        {
            tongDoanhThuDAL = new TongDoanhThu_DAL();
        }

        // Thêm bản ghi doanh thu
        public void ThemTongDoanhThu(TongDoanhThu tongDoanhThu)
        {
            tongDoanhThuDAL.ThemTongDoanhThu(tongDoanhThu);
        }

        // Sửa bản ghi doanh thu
        public void SuaTongDoanhThu(TongDoanhThu tongDoanhThu)
        {
            tongDoanhThuDAL.SuaTongDoanhThu(tongDoanhThu);
        }

        // Xóa bản ghi doanh thu
        public void XoaTongDoanhThu(int maDoanhThu)
        {
            tongDoanhThuDAL.XoaTongDoanhThu(maDoanhThu);
        }

        // Lấy bản ghi doanh thu theo MaDoanhThu
        public TongDoanhThu LayTongDoanhThuTheoMa(int maDoanhThu)
        {
            return tongDoanhThuDAL.LayTongDoanhThuTheoMa(maDoanhThu);
        }

        // Lấy tất cả bản ghi doanh thu
        public IQueryable<TongDoanhThu> LayTatCaTongDoanhThu()
        {
            return tongDoanhThuDAL.LayTatCaTongDoanhThu();
        }

        // Kiểm tra bản ghi doanh thu tồn tại theo MaDonHang
        public bool TongDoanhThuTonTai(int maDonHang)
        {
            return tongDoanhThuDAL.TongDoanhThuTonTai(maDonHang);
        }
    }
}
