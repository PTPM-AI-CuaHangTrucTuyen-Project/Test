using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;

namespace DoAn.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly QuanLyBanHoaDataContext db = new QuanLyBanHoaDataContext(); // Khởi tạo context

        // GET: /OrderHistory/
        public ActionResult OrderHistory()
        {
            // Kiểm tra phiên đăng nhập
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            // Lấy thông tin khách hàng từ session
            KhachHang user = Session["User"] as KhachHang;

            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            // Lấy danh sách đơn hàng của khách hàng
            var orders = db.DonHangs
                .Where(dh => dh.MaKhachHang == user.MaKhachHang)
                .Select(dh => new
                {
                    dh.MaDonHang,
                    dh.NgayDatHang,
                    dh.NgayGiaoHang,
                    dh.DaThanhToan,
                    dh.TinhTrangGiaoHang,
                    ChiTietDonHangs = dh.ChiTietDonHangs.Select(ct => new OrderDetails
                    {
                        TenSanPham = ct.TenSanPham,
                        HinhAnh = ct.HinhAnh,
                        MoTa = db.Hoas.Where(h => h.MaSanPham == ct.MaSanPham).Select(h => h.MoTa).FirstOrDefault(),
                        SoLuong = ct.SoLuong,
                        GiaBan = ct.GiaBan
                    }).ToList()
                })
                .AsEnumerable() // Đưa về phía bộ nhớ để xử lý định dạng ngày
                .Select(dh => new OrderHistory
                {
                    MaDonHang = dh.MaDonHang,
                    NgayDatHang = dh.NgayDatHang,
                    NgayGiaoHang = dh.NgayGiaoHang.HasValue ? dh.NgayGiaoHang.Value.ToString("dd/MM/yyyy") : "Unknow",
                    DaThanhToan = dh.DaThanhToan,
                    TinhTrangGiaoHang = dh.TinhTrangGiaoHang,
                    ChiTietDonHangs = dh.ChiTietDonHangs
                })
                .ToList();

            // Trả về view với danh sách đơn hàng đã được lọc
            return View(orders);
        }

        // POST: /OrderHistory/CancelOrder
        [HttpPost]
        public ActionResult CancelOrders(List<int> maDonHangs)
        {
            try
            {
                foreach (var maDonHang in maDonHangs)
                {
                    // Lấy đơn hàng cần hủy
                    var donHang = db.DonHangs.FirstOrDefault(d => d.MaDonHang == maDonHang);
                    if (donHang != null)
                    {
                        // Xóa chi tiết đơn hàng
                        var chiTietDonHangs = db.ChiTietDonHangs.Where(ct => ct.MaDonHang == maDonHang).ToList();
                        db.ChiTietDonHangs.DeleteAllOnSubmit(chiTietDonHangs);

                        // Xóa bản ghi trong bảng Tổng Doanh Thu
                        var doanhThu = db.TongDoanhThus.FirstOrDefault(dt => dt.MaDonHang == maDonHang);
                        if (doanhThu != null)
                        {
                            db.TongDoanhThus.DeleteOnSubmit(doanhThu);
                        }

                        // Xóa đơn hàng
                        db.DonHangs.DeleteOnSubmit(donHang);
                    }
                }

                // Lưu các thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();
                return RedirectToAction("OrderHistory");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về trang lỗi
                TempData["ErrorMessage"] = "Có lỗi xảy ra: " + ex.Message;
                return RedirectToAction("Error");
            }
        }
    }
}