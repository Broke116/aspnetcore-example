using System;
using aspnetcoreapp1.Helpers;
using aspnetcoreapp1.Middleware;
using aspnetcoreapp1.Repositories;
using aspnetcoreapp1.Services;
using coreapp_database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
            Configuration = configBuilder.Build();
        }

        public IConfiguration Configuration { get; set; } // stores the config object in a property.

        // dependency injection
        public void ConfigureServices(IServiceCollection services)
        {
            //database
            services.AddDbContext<ShopContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddSingleton<IStringFormatter, JsonStringFormatter>();
            services.AddTransient<IGreeter>((provider) => new GreetMessage());
            
            // single instance for per request
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddMvc();
        }
        
        // add middlewares to pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
                    IStringFormatter stringFormatter, ShopContext shopContext)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseMiddleware<LoggerComponent>("Admin", DateTime.UtcNow); // default middleware adding.
            app.UseLoggerComponent("Admin", DateTime.UtcNow); // adding with using extesion class

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitializer.Initialize(shopContext);

            // terminus
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(stringFormatter.FormatIt(new { Message = "Hello World" }));
            //});
        }
    }
}
