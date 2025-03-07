using FinalProject.Entities.Models;
using FinalProject.Repositories;
using FinalProject.Repositories.Contexts;
using FinalProject.Repositories.Contracts;
using FinalProject.Repositories.UnitOfWork;
using FinalProject.Services;
using FinalProject.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using FinalProject.WebApp.Infrastructe.Extensions;

namespace FinalProject.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.ConfigureSession();
            builder.Services.ConfigureDbContext(builder.Configuration);
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureRepositoryRegister();
            builder.Services.ConfigureServiceRegister();
            builder.Services.AddSingleton<Cart>();
            builder.Services.AddAutoMapper(typeof(Program));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            app.Run();
        }


    }
}