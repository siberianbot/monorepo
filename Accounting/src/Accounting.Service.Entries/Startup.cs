using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.DataAccess.Implementation;
using Accounting.Service.Entries.Models.GetEntries;
// using Accounting.Service.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Accounting.Service.Entries
{
    internal sealed class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DatabaseOptions>(_configuration.GetSection("database"));
            
            // TODO:
            // services.AddServiceMethods(builder =>
            // {
            //     builder.Endpoint()
            //         .WithEndpoint(HttpMethods.Post, "/entries")
            //         .WithModel<ListEntriesModel>()
            //         .WithResult<ListEntriesResult>();
            // });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // TODO:
            // app.UseServiceMethods();

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}