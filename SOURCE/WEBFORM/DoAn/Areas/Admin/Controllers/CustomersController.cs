using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;
using DoAn.Areas.Admin.Models;

namespace DoAn.Areas.Admin.Controllers
{
    public class CustomersController : Controller
    {
        private QuanLyBanHoaDataContext db = new QuanLyBanHoaDataContext();
        //
        // GET: /Admin/Customers/
        public ActionResult Feedback()
        {
            var phanHois = db.PhanHois.ToList();
            return View(phanHois);
        }

        public ActionResult Promotions()
        {
            var danhSachTichDiem = db.BangTichDiems.ToList();
            return View(danhSachTichDiem);
        }

        [HttpPost]
        public ActionResult UpdatePromotion(int maKhachHang, int giaTriGiamGia)
        {
            BangTichDiem tichDiem = db.BangTichDiems.FirstOrDefault(td => td.MaKhachHang == maKhachHang);
            if (tichDiem != null)
            {
                tichDiem.GiaTriGiamGia = giaTriGiamGia;
                tichDiem.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
            }

            return RedirectToAction("Promotions");
        }

        public ActionResult Revenue(DateTime? fromDate, DateTime? toDate)
        {
            if (!fromDate.HasValue) fromDate = DateTime.Now.AddDays(-7);
            if (!toDate.HasValue) toDate = DateTime.Now;

            // Nhóm dữ liệu theo ngày
            var doanhThuTheoNgay = db.TongDoanhThus
                .Where(dt => dt.Ngay >= fromDate.Value && dt.Ngay <= toDate.Value)
                .GroupBy(dt => dt.Ngay)
                .Select(group => new RevenueSummary
                {
                    Ngay = group.Key,
                    TongTien = group.Sum(x => x.TongTien),
                    SoLuongHoa = group.Sum(x => x.SoLuongHoa)
                })
                .OrderBy(x => x.Ngay)
                .ToList();

            ViewBag.FromDate = fromDate.Value.ToString("yyyy-MM-dd");
            ViewBag.ToDate = toDate.Value.ToString("yyyy-MM-dd");

            return View(doanhThuTheoNgay);
        }
	}
}