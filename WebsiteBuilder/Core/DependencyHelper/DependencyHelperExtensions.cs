using Microsoft.Extensions.DependencyInjection;
using WebsiteBuilder.Services.IService;
using WebsiteBuilder.Services.Service;

namespace WebsiteBuilder.Core.DependencyHelper
{
    public static class DependencyHelperExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<InterfaceUserTemplate, UserTemplateService>();
        }
    }
}
