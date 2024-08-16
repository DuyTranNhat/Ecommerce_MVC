using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Helpers
{
    public class MyUtils
    {
        public static string UploadImage(IFormFile img, string folder)
		{
			try
			{
				var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", folder, img.FileName);
				using (var myfile = new FileStream(fullPath, FileMode.CreateNew))
				{
					img.CopyTo(myfile);
				}
				return img.FileName;
			}
			catch (Exception ex)
			{
				return string.Empty;
			}
		}

        public static string GenerateRamdomKey(int length = 5)
		{
			var pattern = @"qazwsxedcrfvtgbyhnujmiklopQAZWSXEDCRFVTGBYHNUJMIKLOP!";
			var sb = new StringBuilder();
			var rd = new Random();
			for (int i = 0; i < length; i++)
			{
				sb.Append(pattern[rd.Next(0, pattern.Length)]);
			}

			return sb.ToString();
		}


    }
}