using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Helper
{
    public class BaseObjectSetResponse<T> : IErrorResponse
    {

        public BaseObjectSetResponse()
        {
        }
        public dynamic Data { get; set; }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public int ErrorID { get; set; }
        public string Message { get; set; }
        public Exception OriginalException { get; set; }
        public bool IsSuccess { get; set; }
        public string CustomErrorMessage { get; set; }
    }
}
