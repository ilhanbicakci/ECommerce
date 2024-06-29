using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Models;

namespace Utilities.Tools
{
    public static class FormValidations
    {
        public static CustomResponse TCKNCheck(long tckn)
        {
            CustomResponse response = new CustomResponse();
            if (tckn.ToString().Length == 11)
            {
                long f9 = tckn / 100;
                long l2 = tckn % 100;
                long evens = 0, odds = 0;
                int i = 1;
                while (f9 > 0)
                {
                    long b = f9 % 10;
                    if (i % 2 == 0)
                    {
                        evens += b;
                    }
                    else
                    {
                        odds += b;
                    }
                    f9 /= 10;
                    i++;
                }
                long b10 = (odds * 7 - evens) % 10;
                long b11 = (evens + odds + b10) % 10;
                if (b10 * 10 + b11 == l2)
                {
                    response.Message = "Kimlik numarası geçerli";
                    response.State = true;
                    response.StatusCode = 300;
                }
                else
                {
                    response.Message = "Kimlik numarası geçersiz";
                    response.State = false;
                    response.StatusCode = 400;
                }
            }
            else
            {
                response.Message = "Kimlik numarası 11 haneden oluşmuyor";
                response.State = false;
                response.StatusCode = 404;
            }

            return response;
        }
    }
}
