using DTO;
using DAL;
using System;

namespace BLL
{
    public class NhaCungCap_BLL
    {
        private NhaCungCap_DAL nhaCungCapDAL;

        public NhaCungCap_BLL()
        {
            nhaCungCapDAL = new NhaCungCap_DAL();
        }

        // Thêm nhà cung cấp
        public void ThemNhaCungCap(NhaCungCap nhaCungCap)
        {
            nhaCungCapDAL.ThemNhaCungCap(nhaCungCap);
        }

        // Sửa thông tin nhà cung cấp
        public void SuaNhaCungCap(NhaCungCap nhaCungCap)
        {
            nhaCungCapDAL.SuaNhaCungCap(nhaCungCap);
        }

        // Xóa nhà cung cấp
        public void XoaNhaCungCap(int maNhaCungCap)
        {
            nhaCungCapDAL.XoaNhaCungCap(maNhaCungCap);
        }

        // Lấy thông tin nhà cung cấp theo MaNhaCungCap
        public NhaCungCap LayNhaCungCapTheoMa(int maNhaCungCap)
        {
            return nhaCungCapDAL.LayNhaCungCapTheoMa(maNhaCungCap);
        }

        // Kiểm tra nhà cung cấp tồn tại theo MaNhaCungCap
        public bool NhaCungCapTonTai(int maNhaCungCap)
        {
            return nhaCungCapDAL.NhaCungCapTonTai(maNhaCungCap);
        }

        // Kiểm tra nhà cung cấp tồn tại theo tên nhà cung cấp
        public bool NhaCungCapTonTai(string tenNhaCungCap)
        {
            return nhaCungCapDAL.NhaCungCapTonTai(tenNhaCungCap);
        }
    }
}
