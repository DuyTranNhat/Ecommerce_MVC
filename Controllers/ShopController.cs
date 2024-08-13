using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Ecommerce.ViewModels;

namespace Ecommerce.Controllers
{
    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        private readonly Hshop2023Context _dbContext;

        public ShopController(ILogger<ShopController> logger, Hshop2023Context hshop2023Context)
        {
            _logger = logger;
            _dbContext = hshop2023Context;
        }

        public IActionResult Index(int? loai_sp)
        {
            var listProduct = _dbContext.HangHoas.AsQueryable();

            if (loai_sp.HasValue)
            {
                listProduct = listProduct.Where(hh => hh.MaLoai == loai_sp);
            }

            var result = listProduct.Select(p => new ProductVM
            {
                MaHh = p.MaHh,
                TenHH = p.TenHh,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTaDonVi = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            });

            return View(result);

        }

        public IActionResult Search(string? query_sp)
        {
            var listProduct = _dbContext.HangHoas.AsQueryable();

            if (query_sp != null)
            {
                listProduct = listProduct.Where(hh => hh.TenHh.Contains(query_sp));
            }

            var result = listProduct.Select(p => new
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTaDonVi = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            });

            return View(result);

        }

        public IActionResult Details(int query_sp)
        {
            var sp_existing = _dbContext.HangHoas.Include(hh => hh.MaLoaiNavigation)
                    .SingleOrDefault(hh => hh.MaHh == query_sp);

            if (sp_existing == null) return Redirect("/404");

            var deTails_Product = new Product_DetailsVM {
                MaHh = sp_existing.MaHh,
                TenHH = sp_existing.TenHh,
                Hinh = sp_existing.Hinh,
                DonGia = sp_existing.DonGia ?? 0,
                MoTaNgan = sp_existing.MoTaDonVi,
                TenLoai = sp_existing.MaLoaiNavigation.TenLoai, 
                ChiTiet = sp_existing.MoTa,
                DiemDanhGia = 0,
                SoLuongTon = 0,
            };

            return View(deTails_Product);
        }
    }
}
