using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace DAL
{
    public class KhachHang_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm khách hàng
        public void ThemKhachHang(KhachHang khachHang)
        {
            var newKhachHang = new KhachHang
            {
                TenKhachHang = khachHang.TenKhachHang,
                DiaChi = khachHang.DiaChi,
                SoDienThoai = khachHang.SoDienThoai,
                Email = khachHang.Email,
                NgaySinh = khachHang.NgaySinh,
                TaiKhoan = khachHang.TaiKhoan,
                MatKhau = khachHang.MatKhau,
                GioiTinh = khachHang.GioiTinh
            };
            ql.KhachHangs.InsertOnSubmit(newKhachHang);
            ql.SubmitChanges();
        }

        // Sửa thông tin khách hàng
        public void SuaKhachHang(KhachHang khachHang)
        {
            var existingKhachHang = ql.KhachHangs.SingleOrDefault(k => k.MaKhachHang == khachHang.MaKhachHang);
            if (existingKhachHang != null)
            {
                existingKhachHang.TenKhachHang = khachHang.TenKhachHang;
                existingKhachHang.DiaChi = khachHang.DiaChi;
                existingKhachHang.SoDienThoai = khachHang.SoDienThoai;
                existingKhachHang.Email = khachHang.Email;
                existingKhachHang.NgaySinh = khachHang.NgaySinh;
                existingKhachHang.TaiKhoan = khachHang.TaiKhoan;
                existingKhachHang.MatKhau = khachHang.MatKhau;
                existingKhachHang.GioiTinh = khachHang.GioiTinh;
                ql.SubmitChanges();
            }
        }

        // Sửa thông tin khách hàng theo tài khoản
        public void SuaKhachHangTheoTaiKhoan(KhachHang khachHang)
        {
            var existingKhachHang = ql.KhachHangs.SingleOrDefault(k => k.TaiKhoan == khachHang.TaiKhoan);
            if (existingKhachHang != null)
            {
                existingKhachHang.TenKhachHang = khachHang.TenKhachHang;
                existingKhachHang.DiaChi = khachHang.DiaChi;
                existingKhachHang.SoDienThoai = khachHang.SoDienThoai;
                existingKhachHang.Email = khachHang.Email;
                existingKhachHang.NgaySinh = khachHang.NgaySinh;
                existingKhachHang.MatKhau = khachHang.MatKhau;
                existingKhachHang.GioiTinh = khachHang.GioiTinh;
                ql.SubmitChanges();
            }
        }

        // Xóa khách hàng
        public void XoaKhachHang(int maKhachHang)
        {
            var khachHang = ql.KhachHangs.SingleOrDefault(k => k.MaKhachHang == maKhachHang);
            if (khachHang != null)
            {
                ql.KhachHangs.DeleteOnSubmit(khachHang);
                ql.SubmitChanges();
            }
        }

        // Xóa khách hàng theo tài khoản
        public void XoaKhachHangTheoTaiKhoan(string taiKhoan)
        {
            var khachHang = ql.KhachHangs.SingleOrDefault(k => k.TaiKhoan == taiKhoan);
            if (khachHang != null)
            {
                ql.KhachHangs.DeleteOnSubmit(khachHang);
                ql.SubmitChanges();
            }
        }

        // Lấy tất cả khách hàng
        public List<KhachHang> LayTatCaKhachHang()
        {
            return ql.KhachHangs.ToList();
        }

        // Kiểm tra tài khoản khách hàng tồn tại
        public bool TaiKhoanKhachHangTonTai(string taiKhoan)
        {
            return ql.KhachHangs.Any(k => k.TaiKhoan == taiKhoan);
        }

        // Lấy khách hàng theo ID
        public KhachHang LayKhachHangTheoID(int maKhachHang)
        {
            return ql.KhachHangs.SingleOrDefault(k => k.MaKhachHang == maKhachHang);
        }

        // Kiểm tra số điện thoại có hợp lệ không
        public bool SoDienThoaiHopLe(string soDienThoai)
        {
            return ql.KhachHangs.Any(k => k.SoDienThoai == soDienThoai);
        }

        // Kiểm tra email có hợp lệ không
        public bool EmailHopLe(string email)
        {
            return ql.KhachHangs.Any(k => k.Email == email);
        }

        // Kiểm tra tài khoản và mật khẩu
        public KhachHang DangNhap(string taiKhoan, string matKhau)
        {
            var khachHang = ql.KhachHangs
                .Where(kh => kh.TaiKhoan == taiKhoan && kh.MatKhau == matKhau)
                .FirstOrDefault();

            return khachHang;
        }

        // Lấy tên khách hàng theo tài khoản
        public string LayTenKhachHangTheoTaiKhoan(string taiKhoan)
        {
            var khachHang = ql.KhachHangs.SingleOrDefault(k => k.TaiKhoan == taiKhoan);
            return khachHang != null ? khachHang.TenKhachHang : string.Empty;
        }

        // Tìm kiếm khách hàng theo tên
        public List<KhachHang> TimKiemKhachHangTheoTen(string ten)
        {
            return ql.KhachHangs
                     .Where(kh => kh.TenKhachHang.Contains(ten))  // Tìm kiếm tên khách hàng chứa từ khóa
                     .ToList();
        }

        // Tìm kiếm khách hàng theo tài khoản
        public List<KhachHang> TimKiemKhachHangTheoTaiKhoan(string taiKhoan)
        {
            return ql.KhachHangs
                     .Where(k => k.TaiKhoan.Contains(taiKhoan))  // Tìm tất cả các khách hàng có tài khoản chứa từ khóa
                     .ToList();
        }

        // Tìm kiếm khách hàng theo số điện thoại
        public List<KhachHang> TimKiemKhachHangTheoSoDienThoai(string soDienThoai)
        {
            return ql.KhachHangs
                     .Where(kh => kh.SoDienThoai.Contains(soDienThoai)) // Tìm kiếm số điện thoại chứa từ khóa
                     .ToList();
        }

        // Tìm kiếm khách hàng theo email
        public List<KhachHang> TimKiemKhachHangTheoEmail(string email)
        {
            return ql.KhachHangs
                     .Where(kh => kh.Email.Contains(email)) // Tìm kiếm email chứa từ khóa
                     .ToList();
        }

    }
}
