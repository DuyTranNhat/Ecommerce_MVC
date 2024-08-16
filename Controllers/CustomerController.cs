using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Data;
using Ecommerce.Helpers;
using Ecommerce.Models;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Controllers
{
    public class CustomerController : Controller
    {
        private IMapper _mapper;
        private readonly Hshop2023Context _DBContext;

        public CustomerController(ILogger<CustomerController> logger, IMapper mapper, Hshop2023Context DBcontext)
        {
            _mapper = mapper;
            _DBContext = DBcontext;
        }


        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Register() {
            return View();
        }


        [HttpPost]
        public IActionResult Register(RegisterVM model, IFormFile Hinh) {
            if (ModelState.IsValid) {
                try {
                    var customer = _mapper.Map<KhachHang>(model);
                    customer.HieuLuc = true;
                    customer.VaiTro = 0;
                    customer.RandomKey = MyUtils.GenerateRamdomKey();
                    customer.MatKhau = model.MatKhau.ToMd5Hash(customer.RandomKey); 
                    
                    if(Hinh != null) {
                       customer.Hinh = MyUtils.UploadImage(Hinh, "KhachHang");
                    }

                    _DBContext.KhachHangs.Add(customer);
                    _DBContext.SaveChanges();

                    return RedirectToAction("Index", "Shop");
                } catch (Exception ex) {
                    var mess = $"{ex.Message} shh";
                }
            }   
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}