using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    public class Product_DetailsVM
    {
        public int MaHh { get; set; }
		public string TenHH { get; set; }
		public string Hinh { get; set; }
		public double DonGia { get; set; }
		public string MoTaNgan { get; set; }
		public string TenLoai { get; set; }
		public string ChiTiet { get; set; }
		public int DiemDanhGia { get; set; }
		public int SoLuongTon { get; set; }
    }

	public class ProductVM {
		public int MaHh { get; set; }
		public string TenHH { get; set; }
		public string Hinh { get; set; }
		public double DonGia { get; set; }
		public string MoTaDonVi { get; set; }
		public string TenLoai { get; set; }
	}

}