using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Accounting.Service.Middlewares
{
    public abstract class MiddlewareBase
    {
        private readonly RequestDelegate _next;

        protected MiddlewareBase(RequestDelegate next)
        {
            _next = next;
        }

        public virtual async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
        }
    }
}