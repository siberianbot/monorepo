using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TeamWorks.WebApi
{
    public static class Program
    {
        public static void Main(string[] args) => Host
            .CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureAppConfiguration(ConfigureAppConfiguration)
            .ConfigureLogging(ConfigureLogging)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            .Build()
            .Run();

        private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder builder) => builder
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);

        private static void ConfigureLogging(HostBuilderContext context, ILoggingBuilder builder) => builder
            .AddConsole()
            .AddEventLog();
    }
}