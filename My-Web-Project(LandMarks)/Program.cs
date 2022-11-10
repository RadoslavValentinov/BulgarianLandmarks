using Microsoft.EntityFrameworkCore;
using My_Web_Project_LandMarks_.Infrastructure.Data;
using My_Web_Project_LandMarks_.Infrastructure.Data.Common;
using My_Web_Project_LandMarks_.Infrastructure.Data.Models;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = options.UseSqlServer(connectionString);
        });
        builder.Services.AddScoped<IRepository, Repository>(); ;
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        // add constructor in repositoty inject dbcontext and remove abstract class

        builder.Services.AddDefaultIdentity<Users>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddControllersWithViews();
       

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.Run();
    }
}