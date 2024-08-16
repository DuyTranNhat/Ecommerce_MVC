using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.ViewModels
{
    public class RegisterVM
    {
		[Key]
		[Display(Name = "Username")]
		[Required(ErrorMessage = "*")]
		[MaxLength(20, ErrorMessage = "Lengh of {0} limmited within in 20 characters")]
		public string MaKh { get; set; }


		[Display(Name ="Password")]
		[Required(ErrorMessage = "*")]
		[DataType(DataType.Password)]
		public string MatKhau { get; set; }

		[Display(Name ="Full name")]
		[Required(ErrorMessage = "*")]
		[MaxLength(50, ErrorMessage = "Lengh of {0} limmited within in 50 characters")]
		public string HoTen { get; set; }

		public bool GioiTinh { get; set; } = true;

		[Display(Name ="Birthday")]
		[DataType(DataType.Date)]
		public DateTime? NgaySinh { get; set; }

		[Display(Name ="Address")]
		[MaxLength(60, ErrorMessage = "Lengh of {0} limmited within in 60 characters")]
		public string DiaChi { get; set; }

		[Display(Name = "Phone number")]
		[MaxLength(24, ErrorMessage = "Lengh of {0} limmited within in 24 characters")]
		[RegularExpression(@"0[9875]\d{8}", ErrorMessage ="formart of {0} is not correct!")]
		public string DienThoai { get; set; }


		[EmailAddress(ErrorMessage ="formart of {0} is not correct!")]
		public string Email { get; set; }

		public string? Hinh { get; set; }
    }
}