using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class QuanTriVien_BLL
    {
        private QuanTriVien_DAL quanTriVienDAL;

        public QuanTriVien_BLL()
        {
            quanTriVienDAL = new QuanTriVien_DAL();
        }

        // Thêm quản trị viên
        public void ThemQuanTriVien(QuanTriVien qtv)
        {
            quanTriVienDAL.ThemQuanTriVien(qtv);
        }

        // Sửa quản trị viên
        public void SuaQuanTriVien(QuanTriVien qtv)
        {
            quanTriVienDAL.SuaQuanTriVien(qtv);
        }

        // Xóa quản trị viên
        public void XoaQuanTriVien(int maQTV)
        {
            quanTriVienDAL.XoaQuanTriVien(maQTV);
        }

        // Xóa quản trị viên theo tài khoản
        public void XoaQuanTriVienTheoTaiKhoan(string taiKhoanQTV)
        {
            quanTriVienDAL.XoaQuanTriVienTheoTaiKhoan(taiKhoanQTV);
        }

        // Lấy tất cả quản trị viên
        public List<QuanTriVien> LayTatCaQuanTriVien()
        {
            return quanTriVienDAL.LayTatCaQuanTriVien();
        }

        // Kiểm tra tài khoản quản trị viên tồn tại
        public bool TaiKhoanQuanTriVienTonTai(string taiKhoanQTV)
        {
            return quanTriVienDAL.TaiKhoanQuanTriVienTonTai(taiKhoanQTV);
        }

        // Lấy quản trị viên theo ID
        public QuanTriVien LayQuanTriVienTheoID(int maQTV)
        {
            return quanTriVienDAL.LayQuanTriVienTheoID(maQTV);
        }

        // Kiểm tra email có hợp lệ không
        public bool EmailQuanTriVienHopLe(string email)
        {
            return quanTriVienDAL.EmailQuanTriVienHopLe(email);
        }
        
        //Kiểm tra đăng nhập
        public QuanTriVien DangNhap(string taiKhoan, string matKhau)
        {
            return quanTriVienDAL.DangNhap(taiKhoan, matKhau);
        }

        // Lấy tên quản trị viên theo tài khoản
        public string LayTenQuanTriVienTheoTaiKhoan(string taiKhoan)
        {
            return quanTriVienDAL.LayTenQuanTriVienTheoTaiKhoan(taiKhoan);
        }
        // Lấy danh sách quản trị viên theo tên
        public List<QuanTriVien> LayQuanTriVienTheoTen(string tenQTV)
        {
            return quanTriVienDAL.LayQuanTriVienTheoTen(tenQTV);
        }
        // Lấy tất cả các MaNhomNguoiDung không lặp
        public List<string> LayMaNhomNguoiDungKhongLap()
        {
            return quanTriVienDAL.LayMaNhomNguoiDungKhongLap();
        }
        // Lấy danh sách quản trị viên theo chức vụ (MaNhomNguoiDung)
        public List<QuanTriVien> LayQuanTriVienTheoChucVu(string maNhomNguoiDung)
        {
            return quanTriVienDAL.LayQuanTriVienTheoChucVu(maNhomNguoiDung);
        }

    }
}
