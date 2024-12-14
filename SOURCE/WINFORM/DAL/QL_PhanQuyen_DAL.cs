using DTO;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class QL_PhanQuyen_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm phân quyền
        public void ThemPhanQuyen(QL_PhanQuyen phanQuyen)
        {
            var newPhanQuyen = new QL_PhanQuyen
            {
                MaNhomNguoiDung = phanQuyen.MaNhomNguoiDung,
                MaManHinh = phanQuyen.MaManHinh,
                CoQuyen = phanQuyen.CoQuyen
            };
            ql.QL_PhanQuyens.InsertOnSubmit(newPhanQuyen);
            ql.SubmitChanges();
        }

        // Sửa phân quyền
        public void SuaPhanQuyen(QL_PhanQuyen phanQuyen)
        {
            var existingPhanQuyen = ql.QL_PhanQuyens
                .SingleOrDefault(p => p.MaNhomNguoiDung == phanQuyen.MaNhomNguoiDung && p.MaManHinh == phanQuyen.MaManHinh);
            if (existingPhanQuyen != null)
            {
                existingPhanQuyen.CoQuyen = phanQuyen.CoQuyen;
                ql.SubmitChanges();
            }
        }

        // Kiểm tra phân quyền của nhóm người dùng
        public bool PhanQuyenTonTai(string maNhomNguoiDung, string maManHinh)
        {
            return ql.QL_PhanQuyens.Any(p => p.MaNhomNguoiDung == maNhomNguoiDung && p.MaManHinh == maManHinh);
        }
    }
}
