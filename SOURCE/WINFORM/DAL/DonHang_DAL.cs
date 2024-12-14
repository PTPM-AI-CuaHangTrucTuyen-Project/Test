using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DonHang_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm đơn hàng
        public void ThemDonHang(DonHang donHang)
        {
            ql.DonHangs.InsertOnSubmit(donHang);
            ql.SubmitChanges();
        }

        // Sửa thông tin đơn hàng
        public void SuaDonHang(DonHang donHang)
        {
            var existingDonHang = ql.DonHangs.SingleOrDefault(d => d.MaDonHang == donHang.MaDonHang);
            if (existingDonHang != null)
            {
                existingDonHang.MaKhachHang = donHang.MaKhachHang;
                existingDonHang.NgayDatHang = donHang.NgayDatHang;
                existingDonHang.NgayGiaoHang = donHang.NgayGiaoHang;
                existingDonHang.DaThanhToan = donHang.DaThanhToan;
                existingDonHang.TinhTrangGiaoHang = donHang.TinhTrangGiaoHang;
                ql.SubmitChanges();
            }
        }

        // Xóa đơn hàng
        public void XoaDonHang(int maDonHang)
        {
            var donHang = ql.DonHangs.SingleOrDefault(d => d.MaDonHang == maDonHang);
            if (donHang != null)
            {
                ql.DonHangs.DeleteOnSubmit(donHang);
                ql.SubmitChanges();
            }
        }

        // Lấy tất cả đơn hàng
        public List<DonHang> LayTatCaDonHang()
        {
            return ql.DonHangs.OrderBy(dh => dh.MaKhachHang).ToList();
        }

        // Lọc và sắp xếp đơn hàng theo các điều kiện
        public List<DonHang> LayDonHangTheoLoc(string daThanhToan = "", bool? tinhTrangGiaoHang = null, DateTime? Ngay = null)
        {
            var query = ql.DonHangs.AsQueryable();

            if (!string.IsNullOrEmpty(daThanhToan))
                query = query.Where(d => d.DaThanhToan == daThanhToan);

            if (tinhTrangGiaoHang.HasValue)
                query = query.Where(d => d.TinhTrangGiaoHang == tinhTrangGiaoHang.Value);

            if (Ngay.HasValue)
                query = query.Where(d => d.NgayDatHang.Date == Ngay.Value.Date);

            return query.OrderBy(d => d.MaKhachHang).ToList();
        }

        // Lấy tất cả khách hàng để fill combobox
        public List<KhachHang> LayTatCaKhachHang()
        {
            return ql.KhachHangs.ToList();
        }

        // Tìm kiếm đơn hàng theo tên khách hàng
        public List<DonHang> TimKiemDonHangTheoTenKhachHang(string tenKhachHang)
        {
            return (from dh in ql.DonHangs
                    join kh in ql.KhachHangs on dh.MaKhachHang equals kh.MaKhachHang
                    where kh.TenKhachHang.Contains(tenKhachHang)
                    select dh).ToList();
        }
    }
}
