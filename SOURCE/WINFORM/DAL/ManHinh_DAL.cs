using DTO;
using System.Linq;

namespace DAL
{
    public class ManHinh_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm màn hình
        public void ThemManHinh(ManHinh manHinh)
        {
            var newManHinh = new ManHinh
            {
                MaManHinh = manHinh.MaManHinh,
                TenManHinh = manHinh.TenManHinh
            };
            ql.ManHinhs.InsertOnSubmit(newManHinh);
            ql.SubmitChanges();
        }

        // Lấy tất cả màn hình
        public IQueryable<ManHinh> LayTatCaManHinh()
        {
            return ql.ManHinhs;
        }

        // Kiểm tra màn hình tồn tại
        public bool ManHinhTonTai(string maManHinh)
        {
            return ql.ManHinhs.Any(m => m.MaManHinh == maManHinh);
        }
    }
}
