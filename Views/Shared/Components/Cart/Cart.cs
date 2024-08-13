using Ecommerce.Data;
using Ecommerce.Helpers;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.Components.CategoryMenuComponent
{
    public class Cart : ViewComponent
    {

        private readonly Hshop2023Context _dbContext;
        public List<CartItem> CartSession => HttpContext.Session.Get<List<CartItem>>(MySetting.SessionKeyCart) ?? new List<CartItem>();
        public Cart(Hshop2023Context dbContext) => _dbContext = dbContext;

        public IViewComponentResult Invoke()
        {

            return View(new CartModel {
                Quantity = CartSession.Count,
                TotalPrice = CartSession.Sum(x => x.ThanhTien),
            });
        }
    }
}