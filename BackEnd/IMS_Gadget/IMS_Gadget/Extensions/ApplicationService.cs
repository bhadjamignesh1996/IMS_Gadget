using IMS_Gadget.BalLayer.Interfaces;
using IMS_Gadget.BalLayer.Services;
using IMS_Gadget.Utility;
using Microsoft.AspNetCore.Mvc.Filters;
using static IMS_Gadget.DalLayer.Repositories.Repository_IMSGadget;

namespace IMS_Gadget.Extensions
{
    public static class ApplicationService
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //AddCors

            services.AddCors(options =>
            {
                options.AddPolicy(AppSettings.PolicyName,
                    builder => builder
                    .WithOrigins(AppSettings.WithOrigins) // the Angular app url
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });



            //ActionFilters

            services.AddTransient(typeof(ActionFilters.TokenVerify));

            

            //Repository 

            services.AddTransient(typeof(Repository_Gadgets));
            services.AddTransient(typeof(Repository_Users));



            //Iterface connect with service
            services.AddScoped<IGadget, Service_Gadget>();
            services.AddScoped<IAuthentication, Service_Auth>();
            services.AddTransient(typeof(Service_Common));


            return services;

        }
    }
}
