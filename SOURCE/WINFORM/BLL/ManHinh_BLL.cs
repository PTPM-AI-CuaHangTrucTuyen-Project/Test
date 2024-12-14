using DTO;
using DAL;
using System.Linq;

namespace BLL
{
    public class ManHinh_BLL
    {
        private ManHinh_DAL manHinhDAL;

        public ManHinh_BLL()
        {
            manHinhDAL = new ManHinh_DAL();
        }

        // Thêm màn hình
        public void ThemManHinh(ManHinh manHinh)
        {
            manHinhDAL.ThemManHinh(manHinh);
        }

        // Kiểm tra màn hình tồn tại
        public bool ManHinhTonTai(string maManHinh)
        {
            return manHinhDAL.ManHinhTonTai(maManHinh);
        }

        // Lấy tất cả màn hình
        public IQueryable<ManHinh> LayTatCaManHinh()
        {
            return manHinhDAL.LayTatCaManHinh();
        }
    }
}
