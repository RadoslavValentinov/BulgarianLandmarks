using Microsoft.AspNetCore.Identity.UI.Services;
using My_Web_Project_LandMarks_.Models;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Core.Services.Services;
using MyWebProject.Infrastructure.Data.Common;

namespace My_Web_Project_LandMarks_.Extensions
{

    public static class LandMarkServiceCollectionExtesions
    {
        /// <summary>
        /// Registers all services in the inversion of control container.
        /// </summary>
        /// <param name="services">The service collection to add the services to.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddApplicationServiceApp(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IHomeService, HomeServices>();
            services.AddScoped<ICultureEventService, CultureEventService>();
            services.AddScoped<ITownService, TownService>();
            services.AddScoped<ILandmarkService, LandMarkService>();
            services.AddScoped<ITop10Destination, Top10Destination>();
            services.AddScoped<IMysteryPlace, MysteryPlace>();
            services.AddScoped<IJourneyServise, JourneyService>();
            services.AddScoped<IFactsService, FactsService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IEmailSender, EmailSender>();


            return services;
        }
    }
}
