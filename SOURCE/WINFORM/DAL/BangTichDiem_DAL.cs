using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class BangTichDiem_DAL
    {
        private QUANLYSHOPHOA_NEWDataContext ql = new QUANLYSHOPHOA_NEWDataContext();

        // Thêm bản ghi tích điểm
        public void ThemBangTichDiem(BangTichDiem bangTichDiem)
        {
            var newBangTichDiem = new BangTichDiem
            {
                MaKhachHang = bangTichDiem.MaKhachHang,
                TongDiem = bangTichDiem.TongDiem,
                NgayCapNhat = bangTichDiem.NgayCapNhat
            };
            ql.BangTichDiems.InsertOnSubmit(newBangTichDiem);
            ql.SubmitChanges();
        }

        // Sửa bản ghi tích điểm
        public void SuaBangTichDiem(BangTichDiem bangTichDiem)
        {
            var existingBangTichDiem = ql.BangTichDiems.SingleOrDefault(b => b.MaTichDiem == bangTichDiem.MaTichDiem);
            if (existingBangTichDiem != null)
            {
                existingBangTichDiem.MaKhachHang = bangTichDiem.MaKhachHang;
                existingBangTichDiem.TongDiem = bangTichDiem.TongDiem;
                existingBangTichDiem.NgayCapNhat = bangTichDiem.NgayCapNhat;
                ql.SubmitChanges();
            }
        }

        // Xóa bản ghi tích điểm
        public void XoaBangTichDiem(int maTichDiem)
        {
            var bangTichDiem = ql.BangTichDiems.SingleOrDefault(b => b.MaTichDiem == maTichDiem);
            if (bangTichDiem != null)
            {
                ql.BangTichDiems.DeleteOnSubmit(bangTichDiem);
                ql.SubmitChanges();
            }
        }

        // Lấy bản ghi tích điểm theo MaTichDiem
        public BangTichDiem LayBangTichDiemTheoMa(int maTichDiem)
        {
            return ql.BangTichDiems.SingleOrDefault(b => b.MaTichDiem == maTichDiem);
        }

        // Kiểm tra bản ghi tích điểm tồn tại theo MaKhachHang
        public bool BangTichDiemTonTai(int maKhachHang)
        {
            return ql.BangTichDiems.Any(b => b.MaKhachHang == maKhachHang);
        }

        // Lấy tất cả bản ghi tích điểm
        public List<BangTichDiem> LayTatCaBangTichDiem()
        {
            return ql.BangTichDiems.ToList();
        }
    }
}
