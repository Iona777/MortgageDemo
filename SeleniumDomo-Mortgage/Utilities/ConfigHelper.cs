using Microsoft.Extensions.Configuration;//Needed for Configuation

namespace SeleniumDomo_Mortgage.Utilities
{
    public class ConfigHelper
    {
        //Constructor - does not need one, just use default



        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true);
            
            return builder.Build();
        }
    }
}
