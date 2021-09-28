using Autofac;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoList.DataAccess.Models;

namespace ToDoList.Web
{
    internal sealed class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [UsedImplicitly]
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new WebModule());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DatabaseOptions>(_configuration.GetSection("database"));

            services.AddMvc();
            services.AddRequestLocalization(options =>
            {
                string[] supportedCultures = {"en", "ru"};

                options
                    .SetDefaultCulture(supportedCultures[0])
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRequestLocalization();
            
            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{controller=Task}/{action=Index}"));
        }
    }
}