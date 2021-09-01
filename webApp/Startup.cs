using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using webApp.Authentication;
using webApp.ExceptionHandling;
using webApp.Logging;

namespace webApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory logger)
        {
            //add custom middleware
            //logger.AddLog4Net();
            //app.UseExceptionHandler("/error"); not work, no idea
            app.UseMiddleware<LoggingMiddleware>();

            
            app.UseExceptionHandlerMiddleware();

            app.UseAuthenticationMiddleware();

            
            //terminal is not called if there's any exception
            app.Run(async contex =>
            {
                await contex.Response.WriteAsync("\n Terminal middleware");
            });

        }

    }
}
