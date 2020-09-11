using KikaItems.Contracts.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace KikaItems.BusinessLogic
{
    public class Configurations
    {
        public static void ReadAppSettingFile()
        {
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));

            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var connString = configuration.GetSection("ConnectionString").Value;

            Settings.ConnectionString = connString;

        }
    }
}
