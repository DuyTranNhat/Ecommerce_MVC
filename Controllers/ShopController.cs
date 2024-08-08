using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
