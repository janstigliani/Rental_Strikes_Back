using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace Rental_Strikes_Back
{
    internal static class AppConfig
    {
        public static IConfiguration Configuration { get; private set; }

        static AppConfig()
        {
            if(Configuration == null)
            {
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("AppConfig.json", optional: false, reloadOnChange: true)
                    .Build();
            }
        }

        public static string GetConnectionString()
        {
            return Configuration.GetConnectionString("postgress");
        }
    }
}
