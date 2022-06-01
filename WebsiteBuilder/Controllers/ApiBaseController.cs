using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebsiteBuilder.Helper;

namespace WebsiteBuilder.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        public ApiBaseController(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, ILogger logger)
        {
            _httpContextAccessor = httpContextAccessor;
            Configuration = configuration;
            Logger = logger;
            _identity = _httpContextAccessor?.HttpContext?.User?.Identity as ClaimsIdentity;
            _claims = _identity?.Claims;

            _currentUser.Id = Convert.ToInt64(_claims?.Where(x => x.Type == "UserId").FirstOrDefault()?.Value);
        }

        #region Properties and Data Members

        protected readonly IHttpContextAccessor _httpContextAccessor;
        public readonly ClaimsIdentity _identity;
        public IEnumerable<Claim> _claims { get; }
        public LoggedInUser _currentUser = new LoggedInUser();
        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

        #endregion

        #region helper methods
        public IActionResult HandleResponse<T>(T response) where T : IErrorResponse
        {
            if (response.OriginalException != null)
            {
                ErrorResponse errorResult = response.OriginalException.GetErrorResponse(_currentUser);

                for (int i = 0; i < response.Errors.Count; i++)
                {
                    response.Errors[i] = response.Errors[i] + errorResult.ErrorID;
                }
            }

            if (response.Errors == null || (response.Errors?.Count == 0 && response.Errors?.Count == 0))
            {
                response.IsSuccess = true;

                return Ok(new
                {
                    response
                });
            }
            else
            {
                return BadRequest(new
                {
                    response
                });
            }
        }

        protected IActionResult ReturnBadRequest(Exception ex)
        {
            //throw ex;
            ErrorResponse response = ex.GetErrorResponse(_currentUser, configuration: Configuration);
            return BadRequest(new
            {
                response
            });
        }
        #endregion  
    }
}
