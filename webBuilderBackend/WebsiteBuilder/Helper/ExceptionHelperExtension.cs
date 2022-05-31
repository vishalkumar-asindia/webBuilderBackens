using Microsoft.Extensions.Configuration;
using System;
using WebsiteBuilder.Helper;

namespace Astropush.Infastructure.Extensions
{
    public static class ExceptionHelperExtension
    {
        public static int Log(this Exception exc, LoggedInUser user = null, bool sendEmail = false, IConfiguration configuration = null)
        {
            // TODO Funtion for errro log
            try
            {
                if (configuration != null && configuration["AppEnvironment"] == "dev")
                {
                    sendEmail = false;
                }
                string Description = "Error Detail";
                if (sendEmail)
                {
                    string emailContent = ("Hello Dev Team ,<br/><br/>" + Description + "<br/><br/>" + "Regards <br/>Support Team");
                }
                return 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}