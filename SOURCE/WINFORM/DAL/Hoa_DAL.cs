using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class Hoa_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        public void ThemHoa(Hoa hoa)
        {
            var newHoa = new Hoa
            {
                TenSanPham = hoa.TenSanPham,
                HinhAnh = hoa.HinhAnh,
                MoTa = hoa.MoTa,
                Gia = hoa.Gia,
                DonVi = hoa.DonVi,
                SoLuong = hoa.SoLuong,
                HanSuDung = hoa.HanSuDung,
                MaLoai = hoa.MaLoai
            };
            ql.Hoas.InsertOnSubmit(newHoa);
            ql.SubmitChanges();
        }

        public void SuaHoa(Hoa hoa)
        {
            var existingHoa = ql.Hoas.SingleOrDefault(h => h.TenSanPham == hoa.TenSanPham);
            if (existingHoa != null)
            {
                existingHoa.TenSanPham = hoa.TenSanPham;
                existingHoa.HinhAnh = hoa.HinhAnh;
                existingHoa.MoTa = hoa.MoTa;
                existingHoa.Gia = hoa.Gia;
                existingHoa.DonVi = hoa.DonVi;
                existingHoa.SoLuong = hoa.SoLuong;
                existingHoa.HanSuDung = hoa.HanSuDung;
                existingHoa.MaLoai = hoa.MaLoai;
                ql.SubmitChanges();
            }
        }

        public void XoaHoa(string tenHoa)
        {
            var hoa = ql.Hoas.SingleOrDefault(h => h.TenSanPham == tenHoa);
            if (hoa != null)
            {
                ql.Hoas.DeleteOnSubmit(hoa);
                ql.SubmitChanges();
            }
        }

        public List<Hoa> LayTatCaHoa()
        {
            return ql.Hoas.ToList();
        }

        // Tìm kiếm theo tên sản phẩm
        public List<Hoa> TimKiemHoa(string tenSanPham)
        {
            var query = ql.Hoas.AsQueryable();

            if (!string.IsNullOrEmpty(tenSanPham))
            {
                query = query.Where(h => h.TenSanPham.Contains(tenSanPham));
            }

            return query.ToList();
        }

        public List<LoaiSanPham> LocLoaiSanPham()
        {
            return ql.LoaiSanPhams.Distinct().ToList();
        }

        public List<Hoa> LocHoaTheoLoai(int maLoai)
        {
            return ql.Hoas.Where(h => h.MaLoai == maLoai).ToList();
        }

        public List<Hoa> SapXepTheoTenTangDan()
        {
            return ql.Hoas.OrderBy(h => h.TenSanPham).ToList();
        }

        public List<Hoa> SapXepTheoTenGiamDan()
        {
            return ql.Hoas.OrderByDescending(h => h.TenSanPham).ToList();
        }

        public List<Hoa> SapXepTheoGiaTangDan()
        {
            return ql.Hoas.OrderBy(h => h.Gia).ToList();
        }

        public List<Hoa> SapXepTheoGiaGiamDan()
        {
            return ql.Hoas.OrderByDescending(h => h.Gia).ToList();
        }

    }
}

