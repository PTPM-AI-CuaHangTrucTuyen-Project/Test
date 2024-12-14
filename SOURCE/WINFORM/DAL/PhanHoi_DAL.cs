using DTO;
using System;
using System.Linq;

namespace DAL
{
    public class PhanHoi_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm phản hồi
        public void ThemPhanHoi(PhanHoi phanHoi)
        {
            var newPhanHoi = new PhanHoi
            {
                TenKhachHang = phanHoi.TenKhachHang,
                SoDienThoai = phanHoi.SoDienThoai,
                Email = phanHoi.Email,
                NoiDung = phanHoi.NoiDung,
                ThoiGian = phanHoi.ThoiGian,
                GioiTinh = phanHoi.GioiTinh,
                MaKhachHang = phanHoi.MaKhachHang
            };
            ql.PhanHois.InsertOnSubmit(newPhanHoi);
            ql.SubmitChanges();
        }

        // Sửa phản hồi
        public void SuaPhanHoi(PhanHoi phanHoi)
        {
            var existingPhanHoi = ql.PhanHois.SingleOrDefault(p => p.MaPhanHoi == phanHoi.MaPhanHoi);
            if (existingPhanHoi != null)
            {
                existingPhanHoi.TenKhachHang = phanHoi.TenKhachHang;
                existingPhanHoi.SoDienThoai = phanHoi.SoDienThoai;
                existingPhanHoi.Email = phanHoi.Email;
                existingPhanHoi.NoiDung = phanHoi.NoiDung;
                existingPhanHoi.ThoiGian = phanHoi.ThoiGian;
                existingPhanHoi.GioiTinh = phanHoi.GioiTinh;
                existingPhanHoi.MaKhachHang = phanHoi.MaKhachHang;
                ql.SubmitChanges();
            }
        }

        // Xóa phản hồi
        public void XoaPhanHoi(int maPhanHoi)
        {
            var phanHoi = ql.PhanHois.SingleOrDefault(p => p.MaPhanHoi == maPhanHoi);
            if (phanHoi != null)
            {
                ql.PhanHois.DeleteOnSubmit(phanHoi);
                ql.SubmitChanges();
            }
        }

        // Lấy phản hồi theo MaPhanHoi
        public PhanHoi LayPhanHoiTheoMa(int maPhanHoi)
        {
            return ql.PhanHois.SingleOrDefault(p => p.MaPhanHoi == maPhanHoi);
        }

        // Kiểm tra phản hồi tồn tại theo MaPhanHoi
        public bool PhanHoiTonTai(int maPhanHoi)
        {
            return ql.PhanHois.Any(p => p.MaPhanHoi == maPhanHoi);
        }

        // Lấy tất cả phản hồi
        public IQueryable<PhanHoi> LayTatCaPhanHoi()
        {
            return ql.PhanHois;
        }
    }
}
