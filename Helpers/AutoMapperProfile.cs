using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Models;
using Ecommerce.ViewModels;

namespace Ecommerce.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
		{
			CreateMap<RegisterVM, KhachHang>();
			//.ForMember(kh => kh.HoTen, option => option.MapFrom(RegisterVM => RegisterVM.HoTen))
			//.ReverseMap();
		}
    }
}