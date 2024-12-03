using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using DoAn.Models;
using System.Net.Mail;
using System.Net;

namespace DoAn.Controllers
{
    public class UserController : Controller
    {
        private QuanLyBanHoaDataContext db = new QuanLyBanHoaDataContext();
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult Register(KhachHang DangKy, string SoDienThoai, DateTime? NgaySinh, string DiaChi, string GioiTinh)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(SoDienThoai) && !Regex.IsMatch(SoDienThoai, @"^\d{10}$"))
                {
                    ModelState.AddModelError("SoDienThoai", "Số điện thoại không hợp lệ.");
                }

                if (NgaySinh == null)
                {
                    ModelState.AddModelError("NgaySinh", "Ngày sinh không được để trống.");
                }
                else
                {
                    var age = DateTime.Today.Year - NgaySinh.Value.Year;
                    if (NgaySinh > DateTime.Today || age < 18)
                    {
                        ModelState.AddModelError("NgaySinh", "Bạn phải ít nhất 18 tuổi và ngày sinh không thể là ngày trong tương lai.");
                    }
                }

                if (string.IsNullOrEmpty(DiaChi))
                {
                    ModelState.AddModelError("DiaChi", "Địa chỉ không được để trống.");
                }
                if (string.IsNullOrEmpty(GioiTinh))
                {
                    ModelState.AddModelError("GioiTinh", "Giới tính không được để trống.");
                }

                if (string.IsNullOrEmpty(DangKy.MatKhau) || DangKy.MatKhau.Length < 8)
                {
                    ModelState.AddModelError("MatKhau", "Mật khẩu phải có ít nhất 8 ký tự.");
                }

                if (!string.IsNullOrEmpty(DangKy.Email))
                {
                    if (!IsValidEmail(DangKy.Email))
                    {
                        ModelState.AddModelError("Email", "Email không hợp lệ.");
                    }
                    else if (db.KhachHangs.Any(kh => kh.Email == DangKy.Email))
                    {
                        ModelState.AddModelError("Email", "Email này đã được sử dụng.");
                    }
                }

                if (ModelState.IsValid)
                {
                    KhachHang kh = new KhachHang
                    {
                        TenKhachHang = DangKy.TenKhachHang,
                        TaiKhoan = DangKy.TaiKhoan,
                        MatKhau = DangKy.MatKhau,
                        Email = DangKy.Email,
                        SoDienThoai = SoDienThoai,
                        NgaySinh = NgaySinh,
                        DiaChi = DiaChi,
                        GioiTinh = GioiTinh
                    };


                    db.KhachHangs.InsertOnSubmit(kh);
                    db.SubmitChanges();

                    ViewBag.SuccessMessage = "Sign Up Success";
                    ModelState.Clear(); // Xóa tất cả các lỗi ModelState
                    return View(new KhachHang()); // Tạo một đối tượng KhachHang mới để reset form
                }
            }

            return View(DangKy);
        }

        public ActionResult PartialSuccessView()
        {
            return PartialView();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string TaiKhoan, string MatKhau)
        {
            if (string.IsNullOrEmpty(TaiKhoan) || string.IsNullOrEmpty(MatKhau))
            {
                ModelState.AddModelError("", "Vui lòng nhập tên tài khoản và mật khẩu.");
                return View();
            }

            var user = db.KhachHangs.FirstOrDefault(u => u.TaiKhoan == TaiKhoan && u.MatKhau == MatKhau);
            if (user != null)
            {

                Session["User"] = user;
                Session["LoginSuccess"] = true;
                Session["RegisterSuccess"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác.");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}