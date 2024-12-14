using DTO;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class KhachHang_BLL
    {
        private KhachHang_DAL khachHangDAL;

        public KhachHang_BLL()
        {
            khachHangDAL = new KhachHang_DAL();
        }

        // Thêm khách hàng
        public void ThemKhachHang(KhachHang khachHang)
        {
            khachHangDAL.ThemKhachHang(khachHang);
        }

        // Sửa khách hàng
        public void SuaKhachHang(KhachHang khachHang)
        {
            khachHangDAL.SuaKhachHang(khachHang);
        }

        // Sửa thông tin khách hàng theo tài khoản
        public void SuaKhachHangTheoTaiKhoan(KhachHang khachHang)
        {
            khachHangDAL.SuaKhachHangTheoTaiKhoan(khachHang);
        }

        // Xóa khách hàng
        public void XoaKhachHang(int maKhachHang)
        {
            khachHangDAL.XoaKhachHang(maKhachHang);
        }

        // Lấy tất cả khách hàng
        public List<KhachHang> LayTatCaKhachHang()
        {
            return khachHangDAL.LayTatCaKhachHang();
        }

        // Kiểm tra tài khoản khách hàng tồn tại
        public bool TaiKhoanKhachHangTonTai(string taiKhoan)
        {
            return khachHangDAL.TaiKhoanKhachHangTonTai(taiKhoan);
        }

        // Lấy khách hàng theo ID
        public KhachHang LayKhachHangTheoID(int maKhachHang)
        {
            return khachHangDAL.LayKhachHangTheoID(maKhachHang);
        }

        // Kiểm tra số điện thoại có hợp lệ không
        public bool SoDienThoaiHopLe(string soDienThoai)
        {
            return khachHangDAL.SoDienThoaiHopLe(soDienThoai);
        }

        // Kiểm tra email có hợp lệ không
        public bool EmailHopLe(string email)
        {
            return khachHangDAL.EmailHopLe(email);
        }

        //Kiểm tra đăng nhập
        public KhachHang DangNhap(string taiKhoan, string matKhau)
        {
            return khachHangDAL.DangNhap(taiKhoan, matKhau);
        }

        // Lấy tên khách hàng theo tài khoản
        public string LayTenKhachHangTheoTaiKhoan(string taiKhoan)
        {
            return khachHangDAL.LayTenKhachHangTheoTaiKhoan(taiKhoan);
        }
        // Tìm kiếm khách hàng theo tên
        public List<KhachHang> TimKiemKhachHangTheoTen(string ten)
        {
            return khachHangDAL.TimKiemKhachHangTheoTen(ten);
        }
        // Xóa khách hàng theo tài khoản
        public void XoaKhachHangTheoTaiKhoan(string taiKhoan)
        {
            khachHangDAL.XoaKhachHangTheoTaiKhoan(taiKhoan);
        }
        public List<KhachHang> TimKiemKhachHangTheoTaiKhoan(string taiKhoan)
        {
            return khachHangDAL.TimKiemKhachHangTheoTaiKhoan(taiKhoan);
        }


        // Tìm kiếm khách hàng theo email
        public List<KhachHang> TimKiemKhachHangTheoEmail(string email)
        {
            return khachHangDAL.TimKiemKhachHangTheoEmail(email);
        }
        // Tìm kiếm khách hàng theo số điện thoại
        public List<KhachHang> TimKiemKhachHangTheoSoDienThoai(string soDienThoai)
        {
            return khachHangDAL.TimKiemKhachHangTheoSoDienThoai(soDienThoai);
        }

    }
}
