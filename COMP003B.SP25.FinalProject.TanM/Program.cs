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
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Set up the database context.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Name=ConnectionStrings:DefaultConnection"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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
