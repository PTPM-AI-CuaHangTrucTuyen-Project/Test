using DTO;
using System;
using System.Linq;

namespace DAL
{
    public class TongDoanhThu_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm bản ghi doanh thu
        public void ThemTongDoanhThu(TongDoanhThu tongDoanhThu)
        {
            var newDoanhThu = new TongDoanhThu
            {
                MaDonHang = tongDoanhThu.MaDonHang,
                Ngay = tongDoanhThu.Ngay,
                TongTien = tongDoanhThu.TongTien,
                SoLuongHoa = tongDoanhThu.SoLuongHoa
            };
            ql.TongDoanhThus.InsertOnSubmit(newDoanhThu);
            ql.SubmitChanges();
        }

        // Sửa bản ghi doanh thu
        public void SuaTongDoanhThu(TongDoanhThu tongDoanhThu)
        {
            var existingDoanhThu = ql.TongDoanhThus.SingleOrDefault(t => t.MaDoanhThu == tongDoanhThu.MaDoanhThu);
            if (existingDoanhThu != null)
            {
                existingDoanhThu.MaDonHang = tongDoanhThu.MaDonHang;
                existingDoanhThu.Ngay = tongDoanhThu.Ngay;
                existingDoanhThu.TongTien = tongDoanhThu.TongTien;
                existingDoanhThu.SoLuongHoa = tongDoanhThu.SoLuongHoa;
                ql.SubmitChanges();
            }
        }

        // Xóa bản ghi doanh thu
        public void XoaTongDoanhThu(int maDoanhThu)
        {
            var doanhThu = ql.TongDoanhThus.SingleOrDefault(t => t.MaDoanhThu == maDoanhThu);
            if (doanhThu != null)
            {
                ql.TongDoanhThus.DeleteOnSubmit(doanhThu);
                ql.SubmitChanges();
            }
        }

        // Lấy bản ghi doanh thu theo MaDoanhThu
        public TongDoanhThu LayTongDoanhThuTheoMa(int maDoanhThu)
        {
            return ql.TongDoanhThus.SingleOrDefault(t => t.MaDoanhThu == maDoanhThu);
        }

        // Lấy tất cả bản ghi doanh thu
        public IQueryable<TongDoanhThu> LayTatCaTongDoanhThu()
        {
            return ql.TongDoanhThus;
        }

        // Kiểm tra bản ghi doanh thu tồn tại theo MaDonHang
        public bool TongDoanhThuTonTai(int maDonHang)
        {
            return ql.TongDoanhThus.Any(t => t.MaDonHang == maDonHang);
        }
    }
}
