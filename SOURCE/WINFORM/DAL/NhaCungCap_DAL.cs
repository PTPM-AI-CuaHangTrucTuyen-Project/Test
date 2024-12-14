using DTO;
using System;
using System.Linq;

namespace DAL
{
    public class NhaCungCap_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm nhà cung cấp
        public void ThemNhaCungCap(NhaCungCap nhaCungCap)
        {
            var newNhaCungCap = new NhaCungCap
            {
                TenNhaCungCap = nhaCungCap.TenNhaCungCap,
                HinhAnh = nhaCungCap.HinhAnh,
                DiaChi = nhaCungCap.DiaChi,
                SoDienThoai = nhaCungCap.SoDienThoai,
                Email = nhaCungCap.Email,
                MaSanPham = nhaCungCap.MaSanPham
            };
            ql.NhaCungCaps.InsertOnSubmit(newNhaCungCap);
            ql.SubmitChanges();
        }

        // Sửa thông tin nhà cung cấp
        public void SuaNhaCungCap(NhaCungCap nhaCungCap)
        {
            var existingNhaCungCap = ql.NhaCungCaps.SingleOrDefault(ncc => ncc.MaNhaCungCap == nhaCungCap.MaNhaCungCap);
            if (existingNhaCungCap != null)
            {
                existingNhaCungCap.TenNhaCungCap = nhaCungCap.TenNhaCungCap;
                existingNhaCungCap.HinhAnh = nhaCungCap.HinhAnh;
                existingNhaCungCap.DiaChi = nhaCungCap.DiaChi;
                existingNhaCungCap.SoDienThoai = nhaCungCap.SoDienThoai;
                existingNhaCungCap.Email = nhaCungCap.Email;
                existingNhaCungCap.MaSanPham = nhaCungCap.MaSanPham;
                ql.SubmitChanges();
            }
        }

        // Xóa nhà cung cấp
        public void XoaNhaCungCap(int maNhaCungCap)
        {
            var nhaCungCap = ql.NhaCungCaps.SingleOrDefault(ncc => ncc.MaNhaCungCap == maNhaCungCap);
            if (nhaCungCap != null)
            {
                ql.NhaCungCaps.DeleteOnSubmit(nhaCungCap);
                ql.SubmitChanges();
            }
        }

        // Lấy thông tin nhà cung cấp theo MaNhaCungCap
        public NhaCungCap LayNhaCungCapTheoMa(int maNhaCungCap)
        {
            return ql.NhaCungCaps.SingleOrDefault(ncc => ncc.MaNhaCungCap == maNhaCungCap);
        }

        // Kiểm tra nhà cung cấp tồn tại
        public bool NhaCungCapTonTai(int maNhaCungCap)
        {
            return ql.NhaCungCaps.Any(ncc => ncc.MaNhaCungCap == maNhaCungCap);
        }

        // Kiểm tra nhà cung cấp tồn tại qua tên nhà cung cấp
        public bool NhaCungCapTonTai(string tenNhaCungCap)
        {
            return ql.NhaCungCaps.Any(ncc => ncc.TenNhaCungCap == tenNhaCungCap);
        }
    }
}
