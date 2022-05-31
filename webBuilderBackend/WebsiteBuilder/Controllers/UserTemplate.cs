using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebsiteBuilder.Helper;
using WebsiteBuilder.Models.UserTemplateModel.CreateUserTemplate;
using WebsiteBuilder.Services.IService;

namespace WebsiteBuilder.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

   
    public class UserTemplate : ApiBaseController
    {
        private readonly ILogger<UserTemplate> _logger;
        private readonly InterfaceUserTemplate _interfaceUserTemplate;
        public UserTemplate(
             IHttpContextAccessor httpContextAccessor,
             IConfiguration configuration,
             ILogger<UserTemplate> logger,
              InterfaceUserTemplate interfaceUserTemplate
             ) : base(httpContextAccessor, configuration, logger)
        {
            _logger = logger;
            _interfaceUserTemplate = interfaceUserTemplate;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUserTemplate([FromBody] CreateUserTemplateRequest request)
        {
            try
            {
                BaseObjectSetResponse<CreateUserTemplateResponse> response = await _interfaceUserTemplate.CreateUserTemplateInterface(request);
                return base.HandleResponse(response);
            }
            catch (Exception ex)
            {
                return base.ReturnBadRequest(ex);
            }
        }

        [HttpGet]

        public async Task<IActionResult> GetUserTemplate(string user)
        {
            try
            {
                
                var response = await _interfaceUserTemplate.GetUserTemplateInterface( user);

                return base.HandleResponse(response);
            }
            catch (Exception ex)
            {
                return base.ReturnBadRequest(ex);
            }
        }



    }
}
