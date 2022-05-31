using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Helper
{
    public class ErrorResponse : IErrorResponse
    {
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public int ErrorID { get; set; }
        public Exception OriginalException { get; set; }
        public bool IsSuccess { get; set; }
        public string CustomErrorMessage { get; set; }
    }
}
