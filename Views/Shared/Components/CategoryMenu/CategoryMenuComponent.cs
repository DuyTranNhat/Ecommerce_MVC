
using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Components.CategoryMenuComponent
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly Hshop2023Context _dbContext;
        public CategoryMenuViewComponent(Hshop2023Context dbContext) => _dbContext = dbContext;

        public IViewComponentResult Invoke()
        {
            var data = _dbContext.Loais.Select(lo => new {
                lo.MaLoai, lo.TenLoai, SoLuong = lo.HangHoas.Count
            });
            return View(data);
        }
    }
}