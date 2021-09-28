using System;
using System.Security.Cryptography.X509Certificates;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace TeamWorks.WebApi
{
    internal sealed partial class Startup
    {
        private readonly IConfiguration _configuration;
        
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // ReSharper disable once UnusedMember.Global
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new WebApiModule());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureOptions(services);
            ConfigureControllers(services);
            ConfigureAuthentication(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(builder => builder.MapControllers());
        }
    }
}