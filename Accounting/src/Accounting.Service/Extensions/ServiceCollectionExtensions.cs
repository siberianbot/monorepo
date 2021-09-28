using System;
using Accounting.Service.Builders;
using Accounting.Service.Builders.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Accounting.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceMethods(this IServiceCollection services, Action<IServiceMethodsBuilder> configure)
        {
            ServiceMethodsBuilder builder = new ServiceMethodsBuilder();

            configure(builder);

            services.AddSingleton(builder.Build());

            return services;
        }
    }
}