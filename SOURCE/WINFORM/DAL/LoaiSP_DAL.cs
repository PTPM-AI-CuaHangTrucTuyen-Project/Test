using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class LoaiSP_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm loại sản phẩm
        public void ThemLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            var newLoai = new LoaiSanPham { TenLoai = loaiSanPham.TenLoai };
            ql.LoaiSanPhams.InsertOnSubmit(newLoai);
            ql.SubmitChanges();
        }

        // Sửa loại sản phẩm
        public void SuaLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            var existingLoai = ql.LoaiSanPhams.SingleOrDefault(l => l.MaLoai == loaiSanPham.MaLoai);
            if (existingLoai != null)
            {
                existingLoai.TenLoai = loaiSanPham.TenLoai;
                ql.SubmitChanges();
            }
        }

        // Xóa loại sản phẩm
        public void XoaLoaiSanPham(int maLoai)
        {
            var loaiSanPham = ql.LoaiSanPhams.SingleOrDefault(l => l.MaLoai == maLoai);
            if (loaiSanPham != null)
            {
                ql.LoaiSanPhams.DeleteOnSubmit(loaiSanPham);
                ql.SubmitChanges();
            }
        }

        // Lấy tất cả loại sản phẩm
        public List<LoaiSanPham> LayTatCaLoaiSanPham()
        {
            return ql.LoaiSanPhams.ToList();
        }

        // Kiểm tra loại sản phẩm tồn tại
        public bool LoaiSanPhamTonTai(string tenLoai)
        {
            return ql.LoaiSanPhams.Any(l => l.TenLoai == tenLoai);
        }

        // Lọc loại sản phẩm theo tên
        public List<LoaiSanPham> LocLoaiSanPhamTheoTen(string tenLoai)
        {
            return ql.LoaiSanPhams.Where(l => l.TenLoai.Contains(tenLoai)).ToList();
        }

        // Lấy loại sản phẩm theo ID
        public LoaiSanPham LayLoaiSanPhamTheoID(int maLoai)
        {
            return ql.LoaiSanPhams.SingleOrDefault(l => l.MaLoai == maLoai);
        }
    }
}
