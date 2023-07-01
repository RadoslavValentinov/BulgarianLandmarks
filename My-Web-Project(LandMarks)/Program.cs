using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using My_Web_Project_LandMarks_.ModelBinder;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Core.Services.Services;
using MyWebProject.Infrastructure.Data;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace My_Web_Project_LandMarks_
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                DbContextOptionsBuilder dbContextOptionsBuilder = options.UseSqlServer(connectionString);
            });
            builder.Services.AddDbContext<ApplicationDbContext>();
            builder.Services.AddScoped<IRepository, Repository>();
            builder.Services.AddScoped<IHomeService, HomeServices>();
            builder.Services.AddScoped<ICultureEventService, CultureEventService>();
            builder.Services.AddScoped<ITownService, TownService>();
            builder.Services.AddScoped<ILandmarkService, LandMarkService>();
            builder.Services.AddScoped<ITop10Destination, Top10Destination>();
            builder.Services.AddScoped<IMysteryPlace, MysteryPlace>();
            builder.Services.AddScoped<IJourneyServise, JourneyService>();
            builder.Services.AddScoped<IFactsService,FactsService>();
            builder.Services.AddScoped<ICategoryService,CategoryService>();
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


            builder.Services.AddIdentity<Users, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
            })
            .AddDefaultUI()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation()
            .AddMvcOptions(options =>
            {
                options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "Administrator",
                  pattern: "{area:exists}/{controller=HomeAdmin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");

            });


            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Administrator", "User", "Menager" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Users>>();

                string email = "Repoit@abv.bg";

                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new Users()
                    {
                        Id = "b5a3dd97-a911-493b-88c0-cd062aef88bc",
                        Avatar = "https://us.123rf.com/450wm/anatolir/anatolir2011/anatolir201105528/159470802-jurist-avatar-icon-flat-style.jpg?ver=6",
                        FirstName = "Radoslav",
                        LastName = "Hristov",
                        Email = "Repoit@abv.bg",
                        EmailConfirmed = true,
                        UserName = "Admin",
                        IsActiv = true,
                        NormalizedUserName = "Admin",
                        NormalizedEmail = "Repoit@abv.bg",
                    };

                    await userManager.CreateAsync(user, "Admin3516@");
                    await userManager.AddToRoleAsync(user, "Administrator");
                }

                string menEmail = "maria89@gmail.com";

                if (await userManager.FindByEmailAsync(menEmail) == null)
                {
                    var menagerUser = new Users()
                    {
                        Id = "e8d663de-89f9-40fb-a7a3-ec0f66a18aa5",
                        Avatar = "https://cdn2.vectorstock.com/i/1000x1000/54/41/young-and-elegant-woman-avatar-profile-vector-9685441.jpg",
                        FirstName = "Maria",
                        LastName = "Atanasova",
                        Email = "maria89@gmail.com",
                        IsActiv = true,
                        EmailConfirmed = true,
                        UserName = "maria89@gmail.com",
                        NormalizedEmail = "maria89@gmail.com",
                        NormalizedUserName = "maria89@gmail.com",
                    };

                    await userManager.CreateAsync(menagerUser, "Maria123@");
                    await userManager.AddToRoleAsync(menagerUser, "Menager");
                }
            }

            app.Run();
        }
    }
}