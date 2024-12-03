using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;

namespace DoAn.Controllers
{
    public class ProductsController : Controller
    {
        QuanLyBanHoaDataContext db = new QuanLyBanHoaDataContext();
        //
        // GET: /Products/
        public ActionResult ListProducts(string sortOrder, int? page_list, string searchQuery)
        {
            int page_size = 8;
            int page_number = (page_list ?? 1);

            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price" ? "price_desc" : "price";
            ViewBag.SortOrder = sortOrder;
            ViewBag.SearchQuery = searchQuery;

            // Lọc danh sách sản phẩm theo từ khóa tìm kiếm
            var hoa_list = db.Hoas.AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                hoa_list = hoa_list.Where(s => s.TenSanPham.Contains(searchQuery));
            }

            // Thực hiện sắp xếp theo yêu cầu
            switch (sortOrder)
            {
                case "name_desc":
                    hoa_list = hoa_list.OrderByDescending(s => s.TenSanPham);
                    break;
                case "price":
                    hoa_list = hoa_list.OrderBy(s => s.Gia);
                    break;
                case "price_desc":
                    hoa_list = hoa_list.OrderByDescending(s => s.Gia);
                    break;
                default:
                    hoa_list = hoa_list.OrderBy(s => s.TenSanPham);
                    break;
            }

            // Phân trang
            ViewBag.PageCount = (int)Math.Ceiling((double)hoa_list.Count() / page_size);
            ViewBag.CurrentPage = page_number;
            hoa_list = hoa_list.Skip((page_number - 1) * page_size).Take(page_size);

            return View(hoa_list.ToList());
        }

        public ActionResult FeaturedProducts()
        {
            // Đoạn code lấy tất cả sản phẩm bằng LINQ
            var allProducts = db.Hoas.ToList(); // Replace with your LINQ query

            // Chọn ra 4 sản phẩm đầu tiên bằng LINQ
            var top4Products = allProducts.Take(4).ToList();

            return View(top4Products);
        }
        public ActionResult NewestProducts()
        {
            // Đoạn code lấy tất cả sản phẩm bằng LINQ
            var allProducts = db.Hoas.ToList(); // Thay thế bằng truy vấn LINQ của bạn

            // Sắp xếp sản phẩm theo giá giảm dần và chọn ra 8 sản phẩm đầu tiên
            var top8HighPricedProducts = allProducts.OrderByDescending(p => p.Gia).Take(8).ToList();

            return View(top8HighPricedProducts);
        }
        public ActionResult RandomProducts()
        {
            // Đoạn code lấy tất cả sản phẩm bằng LINQ
            var allProducts = db.Hoas.ToList(); // Thay thế bằng truy vấn LINQ của bạn

            Random random = new Random();

            // Chọn ra 4 sản phẩm ngẫu nhiên
            var randomProducts = allProducts.OrderBy(item => random.Next()).Take(4).ToList();

            return View(randomProducts);
        }

        //
        // GET: /Products/Details/5
        public ActionResult Details(int id)
        {
            var ProductDetail = db.Hoas.FirstOrDefault(s => s.MaSanPham == id);
            return View(ProductDetail);
        }

        //
        // GET: /Products/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
