using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class QuanTriVien_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm quản trị viên
        public void ThemQuanTriVien(QuanTriVien qtv)
        {
            var newQTV = new QuanTriVien
            {
                TenQTV = qtv.TenQTV,
                TaiKhoanQTV = qtv.TaiKhoanQTV,
                MatKhauQTV = qtv.MatKhauQTV,
                EmailQTV = qtv.EmailQTV,
                MaNhomNguoiDung = qtv.MaNhomNguoiDung
            };
            ql.QuanTriViens.InsertOnSubmit(newQTV);
            ql.SubmitChanges();
        }

        // Sửa quản trị viên
        public void SuaQuanTriVien(QuanTriVien qtv)
        {
            var existingQTV = ql.QuanTriViens.SingleOrDefault(q => q.TaiKhoanQTV == qtv.TaiKhoanQTV);
            if (existingQTV != null)
            {
                existingQTV.MatKhauQTV = qtv.MatKhauQTV;
                existingQTV.MaNhomNguoiDung = qtv.MaNhomNguoiDung;

                ql.SubmitChanges();
            }
            else
            {
                throw new Exception("Quản trị viên không tồn tại.");
            }
        }


        // Xóa quản trị viên
        public void XoaQuanTriVien(int maQTV)
        {
            var qtv = ql.QuanTriViens.SingleOrDefault(q => q.MaQTV == maQTV);
            if (qtv != null)
            {
                ql.QuanTriViens.DeleteOnSubmit(qtv);
                ql.SubmitChanges();
            }
        }

        // Xóa quản trị viên theo tài khoản
        public void XoaQuanTriVienTheoTaiKhoan(string taiKhoanQTV)
        {
            var qtv = ql.QuanTriViens.SingleOrDefault(q => q.TaiKhoanQTV == taiKhoanQTV);
            if (qtv != null)
            {
                ql.QuanTriViens.DeleteOnSubmit(qtv);
                ql.SubmitChanges();
            }
        }

        // Lấy tất cả quản trị viên
        public List<QuanTriVien> LayTatCaQuanTriVien()
        {
            return ql.QuanTriViens.ToList();
        }

        // Kiểm tra tài khoản quản trị viên tồn tại
        public bool TaiKhoanQuanTriVienTonTai(string taiKhoanQTV)
        {
            return ql.QuanTriViens.Any(q => q.TaiKhoanQTV == taiKhoanQTV);
        }

        // Lấy quản trị viên theo ID
        public QuanTriVien LayQuanTriVienTheoID(int maQTV)
        {
            return ql.QuanTriViens.SingleOrDefault(q => q.MaQTV == maQTV);
        }

        // Kiểm tra email có hợp lệ không
        public bool EmailQuanTriVienHopLe(string email)
        {
            return ql.QuanTriViens.Any(q => q.EmailQTV == email);
        }

        // Kiểm tra tài khoản và mật khẩu
        public QuanTriVien DangNhap(string taiKhoan, string matKhau)
        {
            var quantrivien = ql.QuanTriViens
                .Where(q => q.TaiKhoanQTV == taiKhoan && q.MatKhauQTV == matKhau)
                .FirstOrDefault();

            return quantrivien;
        }

        // Lấy tên quản trị viên theo tài khoản
        public string LayTenQuanTriVienTheoTaiKhoan(string taiKhoan)
        {
            var quanTriVien = ql.QuanTriViens.SingleOrDefault(q => q.TaiKhoanQTV == taiKhoan);
            return quanTriVien != null ? quanTriVien.TenQTV : string.Empty;
        }

        // Lấy quản trị viên theo tên
        public List<QuanTriVien> LayQuanTriVienTheoTen(string tenQTV)
        {
            return ql.QuanTriViens.Where(q => q.TenQTV.Contains(tenQTV)).ToList();
        }

        // Lấy tất cả các MaNhomNguoiDung không lặp
        public List<string> LayMaNhomNguoiDungKhongLap()
        {
            return ql.QuanTriViens
                      .Select(q => q.MaNhomNguoiDung)
                      .Distinct()
                      .ToList();
        }
        public List<QuanTriVien> LayQuanTriVienTheoChucVu(string maNhomNguoiDung)
        {
            return ql.QuanTriViens
                      .Where(q => q.MaNhomNguoiDung == maNhomNguoiDung)
                      .ToList();
        }

    }
}
