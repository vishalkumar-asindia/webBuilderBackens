using Astropush.Infastructure.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace WebsiteBuilder.Helper
{
    public static class ExceptionHelper
    {
        public static ErrorResponse GetErrorResponse(this Exception ex, LoggedInUser user = null, string customMessage = null, IConfiguration configuration = null)
        {
            string errorMessage = null;
            int errorId = ex.Log(user, configuration: configuration);

            if (String.IsNullOrWhiteSpace(customMessage))
            {
                errorMessage = $"Something went wrong on the server, Please reach out to support and refer to this errorId: {errorId}";
            }
            else
            {
                errorMessage = customMessage + $" Please reach out to support and refer to this errorId: {errorId}";
            }

            return new ErrorResponse { Errors = new List<string> { errorMessage }, IsSuccess = false, ErrorID = errorId };
        }
    }
}
