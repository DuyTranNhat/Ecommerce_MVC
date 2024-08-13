using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.Helpers;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly Hshop2023Context _dbContext;
        public static string SessionKeyCart = "_Cart";

        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(SessionKeyCart) ?? new List<CartItem>();

        public CartController(Hshop2023Context dbContext)
        {
            _dbContext = dbContext;
        }    

        public IActionResult Index()
        {
            return View(Cart);
        }


        public IActionResult Add(int id_product, int quantity = 1)
        {
            var RefCart = Cart;
            var productExisting = _dbContext.HangHoas.SingleOrDefault(hh => hh.MaHh == id_product);
            
            if (productExisting == null)
            {
                ViewData["MessageError"] = "Product is not avalaible!";
                return Redirect("/404");
            }

            //TH1: Co san pham
            var productInCart = RefCart.SingleOrDefault(c => c.MaHh == id_product);

            //TH2: Chua co sp

            if (productInCart == null)
            {
                var newProduct = new CartItem
                {
                    MaHh = productExisting.MaHh,
                    DonGia = productExisting.DonGia ?? 0,
                    Hinh = productExisting.Hinh,
                    SoLuong = quantity,
                    TenHH = productExisting.TenHh
                };

                RefCart.Add(newProduct);
            } else
            {
                productInCart.SoLuong += quantity;
            }
            SaveCart(RefCart);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id_product)
        {
            var RefCart = Cart;
            var productInCart = RefCart.SingleOrDefault(c => c.MaHh == id_product);

            if (productInCart == null)
            {
                return Redirect("/404");
            }

            RefCart.Remove(productInCart);

            SaveCart(RefCart);

            return RedirectToAction("Index");
            }

        public IActionResult UpQuantity(int id_product) {

            var refCart = Cart;
            var productInCart = refCart.SingleOrDefault(c => c.MaHh == id_product);

            if (productInCart == null)
            {
                Redirect("/404");
            }

            productInCart.SoLuong++;
            SaveCart(refCart);

            return Json(new
            {
                success = true,
                newQuantity  = productInCart.SoLuong,
                newTotalPrice = productInCart.ThanhTien,
            });
        }

        public IActionResult DownQuantity(int id_product)
        {
            var refCart = Cart;
            var productInCart = refCart.SingleOrDefault(c => c.MaHh == id_product);

            if (productInCart == null)
            {
                return Redirect("/404");
            }

            if (productInCart.SoLuong <= 0)
            {
                productInCart.SoLuong = 0;
            } else
            {
                productInCart.SoLuong--;
            }

            SaveCart(refCart);

            return Json(new {
                success = true,
                newQuantity = productInCart.SoLuong,
                newTotalPrice = productInCart.ThanhTien,
            });
        }

        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.Set(SessionKeyCart, cart);
        }
    }

}
