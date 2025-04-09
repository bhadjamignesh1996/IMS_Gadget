using IMS_Gadget.DalLayer.DbContexts;
using Microsoft.EntityFrameworkCore;
using IMS_Gadget.Utility;

namespace TheChat.Extensions
{
    public static class ApplicationDbConnection
    {
        public static IServiceCollection AddDbConnection(this IServiceCollection services)
        {
            services.AddDbContextPool<IMSGadgetDB>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(AppSettings.MySQLConnectionString); // Changed to SQL Server
                optionsBuilder.UseApplicationServiceProvider(serviceProvider);
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;
        }
    }
}
