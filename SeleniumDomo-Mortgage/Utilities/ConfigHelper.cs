using Microsoft.Extensions.Configuration;//Needed for Configuation

namespace SeleniumDomo_Mortgage.Utilities
{
    public class ConfigHelper
    {
        private static string configFile = "appsettings.json";
        //Constructor - does not need one, just use default

        //Allows us to read the specified config file
        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile(configFile,
                optional: true,
                reloadOnChange: true);
            
            return builder.Build();
        }
    }
}
