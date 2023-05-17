using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.ExtendMethods;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
{
    public class Startup
    {
        public static string ContentRootPath { set; get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            ContentRootPath = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("AppMvcConnectionString");
                options.UseSqlServer(connectionString);
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            // services.AddTransient<typeof(ILogger<>), typeof(ILogger<>)); //Serilog
            services.Configure<RazorViewEngineOptions>(options =>
            {
                // /View/Controller/Action.cshtml
                // /MyView/Controller/Action.cshtml

                // {0} -> Action Name
                // {1} -> Controller Name
                // {2} -> Area Name

                options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
            });
            // Singleton (Tao 1 lan khi server khoi dong)
            // Scope (Tao moi phien truy cap)
            // Transient (tao moi khi truy van den)
            // services.AddSingleton<ProductService>();
            // services.AddSingleton<ProductService, ProductService>();
            // services.AddSingleton(typeof(ProductService));
            services.AddSingleton(typeof(ProductService), typeof(ProductService));
            services.AddSingleton<PlanetService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.AddStatusCodePage(); // loi tu 400 - 500

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapGet("/sayhi", async context =>
                {
                    await context.Response.WriteAsync("");
                });
                // endpoints.MapControllers
                // endpoints.MapControllerRoute
                // endpoints.MapDefaultControllerRoute
                // endpoints.MapAreaControllerRoute
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "first",
                    pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2,4)}",
                    defaults: new
                    {
                        controller = "First",
                        action = "ViewProduct",
                    },
                    constraints: new
                    {
                        // url = new RegexRouteConstraint(@"^((xemsanpham)|(viewproduct))$"),
                        // id = new RangeRouteConstraint(2, 4),
                    }
                );
                endpoints.MapAreaControllerRoute(
                    name: "product",
                    pattern: "/{controller}/{action=Index}/{id?}",
                    areaName: "ProductManage"
                );

                endpoints.MapControllerRoute(
                    name: "firstroute",
                    pattern: "/{controller=Home}/{action=Index}/{id?}"
                // defaults: new
                // {
                //     controller = "First",
                //     action = "ViewProduct",
                //     // id = 3
                // }
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
