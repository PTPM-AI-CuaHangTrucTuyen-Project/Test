using DTO;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class LoaiSP_BLL
    {
        private LoaiSP_DAL loaiSanPhamDAL;

        public LoaiSP_BLL()
        {
            loaiSanPhamDAL = new LoaiSP_DAL();
        }

        // Thêm loại sản phẩm
        public void ThemLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            loaiSanPhamDAL.ThemLoaiSanPham(loaiSanPham);
        }

        // Sửa loại sản phẩm
        public void SuaLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            loaiSanPhamDAL.SuaLoaiSanPham(loaiSanPham);
        }

        // Xóa loại sản phẩm
        public void XoaLoaiSanPham(int maLoai)
        {
            loaiSanPhamDAL.XoaLoaiSanPham(maLoai);
        }

        // Lấy tất cả loại sản phẩm
        public List<LoaiSanPham> LayTatCaLoaiSanPham()
        {
            return loaiSanPhamDAL.LayTatCaLoaiSanPham();
        }

        // Kiểm tra loại sản phẩm tồn tại
        public bool LoaiSanPhamTonTai(string tenLoai)
        {
            return loaiSanPhamDAL.LoaiSanPhamTonTai(tenLoai);
        }

        // Lọc loại sản phẩm theo tên
        public List<LoaiSanPham> LocLoaiSanPhamTheoTen(string tenLoai)
        {
            return loaiSanPhamDAL.LocLoaiSanPhamTheoTen(tenLoai);
        }

        // Lấy loại sản phẩm theo ID
        public LoaiSanPham LayLoaiSanPhamTheoID(int maLoai)
        {
            return loaiSanPhamDAL.LayLoaiSanPhamTheoID(maLoai);
        }
    }
}
