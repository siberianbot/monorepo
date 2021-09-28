using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ToDoList.Web
{
    public static class Program
    {
        public static Task Main(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureWebHostDefaults(ConfigureWebHostDefaults)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .Build()
                .RunAsync();
        }

        private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder builder)
        {
            builder
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();
        }

        private static void ConfigureWebHostDefaults(IWebHostBuilder builder)
        {
            builder.UseKestrel().UseStartup<Startup>();
        }
    }
}