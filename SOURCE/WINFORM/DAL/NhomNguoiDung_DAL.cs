using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class NhomNguoiDung_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm nhóm người dùng
        public void ThemNhomNguoiDung(NhomNguoiDung nhomNguoiDung)
        {
            var newNhom = new NhomNguoiDung
            {
                MaNhomNguoiDung = nhomNguoiDung.MaNhomNguoiDung,
                TenNhomNguoiDung = nhomNguoiDung.TenNhomNguoiDung
            };
            ql.NhomNguoiDungs.InsertOnSubmit(newNhom);
            ql.SubmitChanges();
        }

        // Sửa nhóm người dùng
        public void SuaNhomNguoiDung(NhomNguoiDung nhomNguoiDung)
        {
            var existingNhom = ql.NhomNguoiDungs.SingleOrDefault(n => n.MaNhomNguoiDung == nhomNguoiDung.MaNhomNguoiDung);
            if (existingNhom != null)
            {
                existingNhom.TenNhomNguoiDung = nhomNguoiDung.TenNhomNguoiDung;
                ql.SubmitChanges();
            }
        }

        // Xóa nhóm người dùng
        public void XoaNhomNguoiDung(string maNhomNguoiDung)
        {
            var nhomNguoiDung = ql.NhomNguoiDungs.SingleOrDefault(n => n.MaNhomNguoiDung == maNhomNguoiDung);
            if (nhomNguoiDung != null)
            {
                ql.NhomNguoiDungs.DeleteOnSubmit(nhomNguoiDung);
                ql.SubmitChanges();
            }
        }

        // Lấy tất cả nhóm người dùng
        public List<NhomNguoiDung> LayTatCaNhomNguoiDung()
        {
            return ql.NhomNguoiDungs.ToList();
        }

        // Lấy nhóm người dùng theo mã
        public NhomNguoiDung LayNhomNguoiDungTheoMa(string maNhomNguoiDung)
        {
            return ql.NhomNguoiDungs.SingleOrDefault(n => n.MaNhomNguoiDung == maNhomNguoiDung);
        }

        // Kiểm tra nhóm người dùng tồn tại
        public bool NhomNguoiDungTonTai(string maNhomNguoiDung)
        {
            return ql.NhomNguoiDungs.Any(n => n.MaNhomNguoiDung == maNhomNguoiDung);
        }
    }
}
