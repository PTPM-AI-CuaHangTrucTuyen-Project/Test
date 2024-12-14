using DAL;
using DTO;
using System.Collections.Generic;

public class Hoa_BLL
{
    private Hoa_DAL hoaDAL = new Hoa_DAL();

    public void ThemHoa(Hoa hoa)
    {
        hoaDAL.ThemHoa(hoa);
    }

    public void SuaHoa(Hoa hoa)
    {
        hoaDAL.SuaHoa(hoa);
    }

    public void XoaHoa(string tenHoa)
    {
        hoaDAL.XoaHoa(tenHoa);
    }

    public List<Hoa> LayTatCaHoa()
    {
        return hoaDAL.LayTatCaHoa();
    }

    // Tìm kiếm theo tên sản phẩm và giá
    public List<Hoa> TimKiemHoa(string tenSanPham)
    {
        return hoaDAL.TimKiemHoa(tenSanPham);
    }

    public List<LoaiSanPham> LocLoaiSanPham()
    {
        return hoaDAL.LocLoaiSanPham();
    }

    public List<Hoa> LocHoaTheoLoai(int maLoai)
    {
        return hoaDAL.LocHoaTheoLoai(maLoai);
    }

    public List<Hoa> SapXepTheoTenTangDan()
    {
        return hoaDAL.SapXepTheoTenTangDan();
    }

    public List<Hoa> SapXepTheoTenGiamDan()
    {
        return hoaDAL.SapXepTheoTenGiamDan();
    }

    public List<Hoa> SapXepTheoGiaTangDan()
    {
        return hoaDAL.SapXepTheoGiaTangDan();
    }

    public List<Hoa> SapXepTheoGiaGiamDan()
    {
        return hoaDAL.SapXepTheoGiaGiamDan();
    }
}
