using eFurniture.Data;
using eFurniture.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace eFurniture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // **ENSURE THIS LINE IS PRESENT AND NOT COMMENTED OUT - REGISTER RAZOR PAGES SERVICES**
            builder.Services.AddRazorPages();

            // Add DbContext service
            builder.Services.AddDbContext<EFurnitureDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("EFurnitureDbContext"))); // **Using "EFurnitureDbContext" connection string as requested**


            // **Add Cookie Authentication Services:**
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/Account/Login"; // Set login path
                    options.AccessDeniedPath = "/Account/AccessDenied"; // Set access denied path
                });

            var app = builder.Build();

            // Seed initial data (moved from previous location - ensure it's after builder.Build())
            using (var serviceScope = app.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<EFurnitureDbContext>();
                context.Database.Migrate();
                // Data seeding is now configured in ApplicationDbContext's OnModelCreating using HasData()
            }


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // Enable serving static files (wwwroot)
            app.UseRouting();      // **Ensure UseRouting() is present**

            app.UseAuthentication(); // Enable authentication middleware (important for Identity)
            app.UseAuthorization(); // Enable authorization middleware

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); // Default route for MVC

            // **ENSURE THIS LINE IS PRESENT AND NOT COMMENTED OUT - MAP RAZOR PAGES ENDPOINTS**
            app.MapRazorPages(); // If you are using Razor Pages in addition to MVC, keep this

            app.Run();
        }
    }
}