using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Models
{
    public class CustomResponse
    {
        public int StatusCode { get; set; }
        public bool State { get; set; }
        public string Message { get; set; }

        public CustomResponse(int statusCode, bool state, string message)
        {
            StatusCode = statusCode;
            State = state;
            Message = message;
        }

        public CustomResponse()
        {
        }
    }
}
