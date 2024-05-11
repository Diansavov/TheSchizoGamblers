using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using TheSchizoGamblers.Data;
using TheSchizoGamblers.Models;

namespace TheSchizoGamblers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<GamblersContext>(options =>
             options.UseMySql(builder.Configuration.GetConnectionString("GamblersConnectionString"), new MySqlServerVersion(new Version(10, 0, 1))));

            builder.Services.AddDefaultIdentity<GamblersModel>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<GamblersContext>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            });
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "GamblerCookie";
                options.LoginPath = "/Gamblers/LogIn";
            });

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

            RolesSeed.Seed(app);
            
            app.Run();
        }
    }
}