using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBuilder.Helper;
using WebsiteBuilder.Models.UserTemplateModel.CreateUserTemplate;

namespace WebsiteBuilder.Services.IService
{
   public interface InterfaceUserTemplate
    {
        Task<BaseObjectSetResponse<CreateUserTemplateResponse>> CreateUserTemplateInterface(CreateUserTemplateRequest request);
        Task<BaseObjectSetResponse<CreateUserTemplateResponse>> GetUserTemplateInterface(string user);

    }
}
