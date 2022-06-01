using System;
using System.Collections.Generic;

namespace WebsiteBuilder.Helper
{
    public interface IErrorResponse
    {
        public int StatusCode { get; set; }

        List<string> Errors { get; set; }
        int ErrorID { get; set; }
        Exception OriginalException { get; set; }
        bool IsSuccess { get; set; }
        public string CustomErrorMessage { get; set; }
    }
}
