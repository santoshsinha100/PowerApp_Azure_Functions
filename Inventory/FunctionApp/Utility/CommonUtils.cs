using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Utility
{
    public static class CommonUtils
    {
        /// <summary>
        /// to read configuration settings
        /// </summary>
        private static IConfiguration configuration = CommonUtils.GetConfig();

        /// <summary>
        /// the TableStorageConnectionString
        /// </summary>
        public static string TableStorageConnectionString
        {
            get
            {
                if (configuration != null && configuration["Values:TableStorageConnectionString"] != null)
                {
                    return configuration["Values:TableStorageConnectionString"];
                }
                return string.Empty;
              }
        }       

        /// <summary>
        /// to read configuration settings.
        /// </summary>
        /// <returns></returns>
        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json",
                optional: true,
                reloadOnChange: true);

            return builder.Build();
        }

    }
}
