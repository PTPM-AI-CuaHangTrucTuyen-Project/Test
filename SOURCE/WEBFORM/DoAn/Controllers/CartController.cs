using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;

namespace DoAn.Controllers
{
    public class CartController : Controller
    {
        QuanLyBanHoaDataContext db = new QuanLyBanHoaDataContext();
        //
        // GET: /Cart/
        public ActionResult Index()
        {
            return View();
        }
        public List<Cart> LayGioHang()
        {
            List<Cart> lstGioHang = Session["Cart"] as List<Cart>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<Cart>();
                Session["Cart"] = lstGioHang;
            }
            return lstGioHang;
        }

        [HttpPost]
        public ActionResult ThemGioHang(int mSP, string a)
        {
            List<Cart> lstGioHang = LayGioHang();
            Cart SanPham = lstGioHang.Find(sp => sp.iMaSanPham == mSP);
            if (SanPham == null)
            {
                SanPham = new Cart(mSP);
                lstGioHang.Add(SanPham);
            }
            else
            {
                SanPham.iSoLuong++;
            }

            Session["Cart"] = lstGioHang;


            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();

            return RedirectToAction("Cart");
        }
        private int TongSoLuong()
        {
            int tsl = 0;
            List<Cart> lstGioHang = Session["Cart"] as List<Cart>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Sum(sp => sp.iSoLuong);
            }
            return tsl;
        }
        private double TongThanhTien()
        {
            double ttt = 0;
            List<Cart> lstGioHang = Session["Cart"] as List<Cart>;
            if (lstGioHang != null)
            {
                ttt += lstGioHang.Sum(sp => sp.dThanhTien);
            }
            return ttt;

        }
        public ActionResult Cart()
        {
            List<Cart> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            // Tính giá trị giảm giá và tổng tiền sau khi giảm
            // Kiểm tra nếu chưa đăng nhập
            if (Session["User"] == null)
            {
                // Nếu chưa đăng nhập, giá trị giảm giá sẽ là 0 và tổng tiền không thay đổi
                ViewBag.GiaTriGiamGia = 0;
                ViewBag.TongThanhTienSauGiamGia = ViewBag.TongThanhTien;
            }
            else
            {
                // Nếu đã đăng nhập, lấy thông tin mã khách hàng và giá trị giảm giá
                KhachHang user = Session["User"] as KhachHang;
                BangTichDiem tichDiem = db.BangTichDiems.FirstOrDefault(td => td.MaKhachHang == user.MaKhachHang);

                ViewBag.GiaTriGiamGia = tichDiem.GiaTriGiamGia ?? 0; // Nếu không có giảm giá, giá trị mặc định là 0
                ViewBag.TongThanhTienSauGiamGia = Math.Max(ViewBag.TongThanhTien - ViewBag.GiaTriGiamGia, 0);
            }
            return View(lstGioHang);
        }
        [HttpDelete]
        public ActionResult XoaGioHang(int iMaSanPham)
        {
            List<Cart> lstGioHang = LayGioHang();
            Cart sanPham = lstGioHang.Find(sp => sp.iMaSanPham == iMaSanPham);

            if (sanPham != null)
            {
                lstGioHang.Remove(sanPham);
                Session["Cart"] = lstGioHang;
            }

            return RedirectToAction("Cart");
        }
        [HttpPost]
        public ActionResult XoaHetGioHang()
        {
            Session["Cart"] = null;
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public ActionResult CapNhatGioHang(int iMaSanPham, int iSoLuongMoi)
        {
            List<Cart> lstGioHang = LayGioHang();
            Cart sanPham = lstGioHang.Find(sp => sp.iMaSanPham == iMaSanPham);

            if (sanPham != null)
            {

                sanPham.iSoLuong = iSoLuongMoi;

                Session["Cart"] = lstGioHang;
            }

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult Order(string TenKhachHang, string DiaChi, string SoDienThoai)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            KhachHang user = Session["User"] as KhachHang;
            List<Cart> cart = Session["Cart"] as List<Cart>;

            if (cart == null || !cart.Any())
            {
                return RedirectToAction("Cart");
            }

            // Lấy thông tin giảm giá
            BangTichDiem tichDiem = db.BangTichDiems.FirstOrDefault(td => td.MaKhachHang == user.MaKhachHang);
            int giaTriGiamGia = tichDiem.GiaTriGiamGia ?? 0;

            // Tính tổng tiền sau giảm giá
            double tongTien = cart.Sum(sp => sp.dThanhTien);
            double tongTienSauGiamGia = Math.Max(tongTien - giaTriGiamGia, 0); // Không âm

            // Cập nhật ViewBag để truyền thông tin cho View
            ViewBag.GiaTriGiamGia = giaTriGiamGia;
            ViewBag.TongThanhTienSauGiamGia = tongTienSauGiamGia;

            // Tạo đối tượng DonHang
            DonHang donHang = new DonHang
            {
                MaKhachHang = user.MaKhachHang,
                NgayDatHang = DateTime.Now,
                DaThanhToan = "Đã thanh toán",
                TinhTrangGiaoHang = false, // Đặt ban đầu là false, sẽ cập nhật sau khi thêm chi tiết
                NgayGiaoHang = DateTime.Now.AddDays(14)
            };

            // Thêm DonHang vào CSDL
            db.DonHangs.InsertOnSubmit(donHang);
            db.SubmitChanges();

            // Thêm ChiTietDonHang
            foreach (Cart item in cart)
            {
                ChiTietDonHang chiTietDonHang = new ChiTietDonHang
                {
                    MaDonHang = donHang.MaDonHang,
                    MaSanPham = item.iMaSanPham,
                    TenSanPham = item.sTenSanPham,
                    HinhAnh = item.sHinhAnh,
                    SoLuong = item.iSoLuong,
                    GiaBan = (decimal)item.dGiaBan
                };

                db.ChiTietDonHangs.InsertOnSubmit(chiTietDonHang);
            }

            db.SubmitChanges();

            // Cập nhật trạng thái giao hàng để kích hoạt trigger
            donHang.TinhTrangGiaoHang = true;
            db.SubmitChanges();

            // Reset giá trị giảm giá sau khi áp dụng
            if (tichDiem != null)
            {
                tichDiem.GiaTriGiamGia = 0;
                db.SubmitChanges();
            }

            // Tích điểm khuyến mãi
            int tongDiemMoi = (int)(tongTienSauGiamGia / 10);
            if (tichDiem == null)
            {
                tichDiem = new BangTichDiem
                {
                    MaKhachHang = user.MaKhachHang,
                    TongDiem = tongDiemMoi,
                    NgayCapNhat = DateTime.Now
                };
                db.BangTichDiems.InsertOnSubmit(tichDiem);
            }
            else
            {
                tichDiem.TongDiem += tongDiemMoi;
                tichDiem.NgayCapNhat = DateTime.Now;
            }

            db.SubmitChanges();

            // Xóa giỏ hàng
            Session["Cart"] = null;

            return RedirectToAction("OrderSuccess");
        }


        public ActionResult OrderSuccess()
        {
            return View();
        }

        public ActionResult PartialCart()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            return PartialView();
        }
    }
}