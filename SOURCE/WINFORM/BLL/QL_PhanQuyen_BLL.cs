using DTO;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class QL_PhanQuyen_BLL
    {
        private QL_PhanQuyen_DAL phanQuyenDAL;

        public QL_PhanQuyen_BLL()
        {
            phanQuyenDAL = new QL_PhanQuyen_DAL();
        }

        // Thêm phân quyền
        public void ThemPhanQuyen(QL_PhanQuyen phanQuyen)
        {
            phanQuyenDAL.ThemPhanQuyen(phanQuyen);
        }

        // Sửa phân quyền
        public void SuaPhanQuyen(QL_PhanQuyen phanQuyen)
        {
            phanQuyenDAL.SuaPhanQuyen(phanQuyen);
        }

        // Kiểm tra phân quyền tồn tại
        public bool PhanQuyenTonTai(string maNhomNguoiDung, string maManHinh)
        {
            return phanQuyenDAL.PhanQuyenTonTai(maNhomNguoiDung, maManHinh);
        }
    }
}
