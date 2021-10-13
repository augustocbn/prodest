using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using CitiesWebsite.Services;
using Microsoft.Extensions.Hosting;

namespace CitiesWebsite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<ICityProvider, CityProvider>();
            services.AddSingleton<ICityFormatter, CityFormatter>();
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

            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                name: "Default",
                pattern: "{controller}/{action}",
                defaults: new { controller = "City", action = "ShowCities" });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });
        }
    }
}
