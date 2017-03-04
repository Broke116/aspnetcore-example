using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcoreapp1.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace aspnetcoreapp1
{
    public class Startup
    {
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

            // terminus
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(stringFormatter.FormatIt(new { Message = "Hello World" }));
            });
        }
    }
}
