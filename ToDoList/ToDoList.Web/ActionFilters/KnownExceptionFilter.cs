using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using ToDoList.Models;
using ToDoList.Web.Models;

namespace ToDoList.Web.ActionFilters
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal sealed class KnownExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<KnownExceptionFilter> _logger;

        public KnownExceptionFilter(ILogger<KnownExceptionFilter> logger)
        {
            _logger = logger;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case DomainException domainException:
                    context.Result = new BadRequestObjectResult(FailureModel.CreateFor(domainException));
                    break;

                default:
                    _logger.LogError(context.Exception, "Unhandled exception occurred");

                    // TODO l10n
                    context.Result = new ObjectResult(FailureModel.CreateFor("Unhandled exception occurred"))
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
                    break;
            }

            return Task.CompletedTask;
        }
    }
}