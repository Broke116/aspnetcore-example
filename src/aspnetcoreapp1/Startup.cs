using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using aspnetcoreapp1.Helpers;
using aspnetcoreapp1.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace aspnetcoreapp1
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            var configRoot = configBuilder.Build();
        }

        // dependency injection
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IStringFormatter, JsonStringFormatter>();
            services.AddTransient<IGreeter>((provider) => new GreetMessage());
        }
        
        // add middlewares to pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
                    IStringFormatter stringFormatter)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMiddleware<LoggerComponent>("Admin", DateTime.UtcNow); // default middleware adding.
            app.UseLoggerComponent("Admin", DateTime.UtcNow); // adding with using extesion class

            // terminus
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(stringFormatter.FormatIt(new { Message = "Hello World" }));
            });
        }
    }
}
