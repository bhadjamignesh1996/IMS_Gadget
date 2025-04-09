using Microsoft.Extensions.Configuration;

namespace IMS_Gadget.Utility
{
    public static class AppSettings
    {

        static AppSettings()
        {
            IConfigurationRoot objConfig = new ConfigurationBuilder()
                                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                   .AddJsonFile("appsettings.json")
                                   .Build();

            MySQLConnectionString = objConfig.GetValue<string>("ConnectionStrings:MySQLConnectionString");
            WithOrigins = objConfig.GetValue<string>("WithOrigins").Split(",");
            PolicyName = "IMSGadgetCorePolicy";
            JwtKey = "MEQO3WI7JK2VNoaDvbncja/ZkqPLMNB30c+aR4yHzygn5qNBVcvbtBpw4+SwZh4+NBVCXi3KJHlSXKPri6bXr8==";
            JwtIssuer = "IMSGadget";
            JwtAudience = "Audience";
            JwtAddExpireTime = "100";
        }

        public static string MySQLConnectionString { get; }
        public static string[] WithOrigins { get; }
        public static string PolicyName { get; }
        public static string JwtKey { get; }
        public static string JwtIssuer { get; }
        public static string JwtAudience { get; }
        public static string JwtAddExpireTime { get; }



    }
}
