using Accounting.Service.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Accounting.Service.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseServiceMethods(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ServiceMethodsMiddleware>();
        }
    }
}