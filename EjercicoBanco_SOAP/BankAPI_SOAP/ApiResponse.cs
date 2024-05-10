using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankAPI_SOAP
{
    public class ApiResponse
    {
        public string ResponseCode { get; protected set; }
        public string ResponseDescription { get; protected set; }
        public string Message { get; set; }
        private ApiResponse() { }
        public static ApiResponse Success(string message)
        {
            return new ApiResponse
            {
                ResponseCode = "200",
                ResponseDescription = "Ok",
                Message = message
            };
        }
        public static ApiResponse Failure(string message)
        {
            return new ApiResponse
            {
                ResponseCode = "500",
                ResponseDescription = "Internal Server Error",
                Message = message
            };
        }
    }
}