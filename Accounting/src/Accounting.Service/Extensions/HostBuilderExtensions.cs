using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Accounting.Service.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder UseAutofac<TModule>(this IHostBuilder hostBuilder)
            where TModule : Module, new()
        {
            AutofacServiceProviderFactory serviceProviderFactory = new AutofacServiceProviderFactory(containerBuilder => containerBuilder.RegisterModule<TModule>());

            return hostBuilder.UseServiceProviderFactory(serviceProviderFactory);
        }

        public static IHostBuilder UseDefaultAppConfiguration(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureAppConfiguration((context, builder) =>
            {
                builder
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();
            });
        }

        public static IHostBuilder UseDefaultLogging(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureLogging((context, builder) =>
            {
                builder.AddConsole();

                if (context.HostingEnvironment.IsDevelopment())
                {
                    builder.AddDebug();
                }
            });
        }
    }
}