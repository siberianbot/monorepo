using System.Threading.Tasks;
using Accounting.Service.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Accounting.Service.Entries
{
    public static class Program
    {
        public static Task Main(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel();
                    webBuilder.UseStartup<Startup>();
                })
                .UseDefaultAppConfiguration()
                .UseDefaultLogging()
                .UseAutofac<EntriesServiceModule>()
                .Build()
                .RunAsync();
        }
    }
}