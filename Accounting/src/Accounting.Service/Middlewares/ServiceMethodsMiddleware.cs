using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Accounting.Service.Infrastructure;
using Accounting.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;

namespace Accounting.Service.Middlewares
{
    public sealed class ServiceMethodsMiddleware : MiddlewareBase
    {
        private readonly ServiceMethodEndpointsCollection _endpointsCollection;
        private readonly IModelBinderProvider _modelBinderProvider;
        private readonly IModelBinderFactory _modelBinderFactory;
        private readonly IModelMetadataProvider _modelMetadataProvider;
        private readonly IServiceProvider _serviceProvider;

        public ServiceMethodsMiddleware(
            ServiceMethodEndpointsCollection endpointsCollection,
            // IServiceMethodExecutor executionMediator, TODO: execution mediator should resolve appropriate service method.
            IModelBinderProvider modelBinderProvider,
            IModelBinderFactory modelBinderFactory,
            IModelMetadataProvider modelMetadataProvider,
            IServiceProvider serviceProvider,
            RequestDelegate next)
            : base(next)
        {
            _endpointsCollection = endpointsCollection;
            _modelBinderProvider = modelBinderProvider;
            _modelBinderFactory = modelBinderFactory;
            _modelMetadataProvider = modelMetadataProvider;
            _serviceProvider = serviceProvider;
        }

        public override async Task InvokeAsync(HttpContext context)
        {
            await ResolveServiceMethod(context);

            await base.InvokeAsync(context);
        }

        private async Task ResolveServiceMethod(HttpContext context)
        {
            ServiceMethodEndpoint methodEndpoint = _endpointsCollection.Endpoints
                .Where(endpoint => string.Equals(endpoint.Method, context.Request.Method, StringComparison.OrdinalIgnoreCase))
                // TODO: maybe it should be case sensitive
                .FirstOrDefault(endpoint => string.Equals(endpoint.Path, context.Request.Path, StringComparison.OrdinalIgnoreCase));

            if (methodEndpoint == null)
            {
                await HandleNotFoundAsync(context.Response);
                
                return;
            }

            IModelBinder binder = _modelBinderFactory.CreateBinder(new ModelBinderFactoryContext
            {
                Metadata = _modelMetadataProvider.GetMetadataForType(methodEndpoint.ModelType)
            });

            await binder.BindModelAsync(new DefaultModelBindingContext
            {
                
            });
            
            Type methodType = typeof(IServiceMethod<,>).MakeGenericType(methodEndpoint.ModelType, methodEndpoint.ResultType);
            object methodInstance = _serviceProvider.GetService(methodType);

            await (methodType.GetMethod("ExecuteAsync", BindingFlags.Public | BindingFlags.Instance)!.Invoke(methodInstance, new object[] { null }) as Task);
            
            return;
        }

        private async Task HandleNotFoundAsync(HttpResponse response)
        {
            response.StatusCode = StatusCodes.Status404NotFound;

            await response.CompleteAsync();
        }
    }
}