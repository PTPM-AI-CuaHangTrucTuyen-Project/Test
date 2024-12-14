using DTO;
using DAL;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BLL
{
    public class NhomNguoiDung_BLL
    {
        private NhomNguoiDung_DAL nhomNguoiDungDAL;

        public NhomNguoiDung_BLL()
        {
            nhomNguoiDungDAL = new NhomNguoiDung_DAL();
        }

        // Thêm nhóm người dùng
        public void ThemNhomNguoiDung(NhomNguoiDung nhomNguoiDung)
        {
            nhomNguoiDungDAL.ThemNhomNguoiDung(nhomNguoiDung);
        }

        // Sửa nhóm người dùng
        public void SuaNhomNguoiDung(NhomNguoiDung nhomNguoiDung)
        {
            nhomNguoiDungDAL.SuaNhomNguoiDung(nhomNguoiDung);
        }

        // Xóa nhóm người dùng
        public void XoaNhomNguoiDung(string maNhomNguoiDung)
        {
            nhomNguoiDungDAL.XoaNhomNguoiDung(maNhomNguoiDung);
        }

        // Lấy tất cả nhóm người dùng
        public List<NhomNguoiDung> LayTatCaNhomNguoiDung()
        {
            return nhomNguoiDungDAL.LayTatCaNhomNguoiDung().ToList();
        }

        // Lấy nhóm người dùng theo mã
        public NhomNguoiDung LayNhomNguoiDungTheoMa(string maNhomNguoiDung)
        {
            return nhomNguoiDungDAL.LayNhomNguoiDungTheoMa(maNhomNguoiDung);
        }

        // Kiểm tra nhóm người dùng tồn tại
        public bool NhomNguoiDungTonTai(string maNhomNguoiDung)
        {
            return nhomNguoiDungDAL.NhomNguoiDungTonTai(maNhomNguoiDung);
        }
    }
}
