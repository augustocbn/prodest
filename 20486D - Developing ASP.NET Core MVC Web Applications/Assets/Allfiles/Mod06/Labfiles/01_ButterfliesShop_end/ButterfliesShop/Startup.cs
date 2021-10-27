using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButterfliesShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ButterfliesShop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IDataService, DataService>();
            services.AddSingleton<IButterfliesQuantityService, ButterfliesQuantityService>();
        }

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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "ButterflyRoute",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Butterfly", action = "Index" });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });

        }
    }
}
