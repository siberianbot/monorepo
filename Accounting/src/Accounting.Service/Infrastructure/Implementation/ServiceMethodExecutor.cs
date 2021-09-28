using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Accounting.Service.Infrastructure.Implementation
{
    internal sealed class ServiceMethodExecutor : IServiceMethodExecutor
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceMethodExecutor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> ExecuteAsync<TModel, TResult>(TModel model)
        {
            return await _serviceProvider.GetRequiredService<IServiceMethod<TModel, TResult>>().ExecuteAsync(model);
        }
    }
}