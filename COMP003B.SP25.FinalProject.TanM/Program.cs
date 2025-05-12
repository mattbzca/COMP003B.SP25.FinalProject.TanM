/*
 * Author: Matthew Tan
 * Course: COMP-003B: ASP.NET Core
 * Instructor: Jonathan Cruz
 * Purpose: Final project synthesizing MVC, Web API, EF Core, and middleware
 */
using COMP003B.SP25.FinalProject.TanM.Data;
using Microsoft.EntityFrameworkCore;
namespace COMP003B.SP25.FinalProject.TanM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Set up the database context.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Name=ConnectionStrings:DefaultConnection"));

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
