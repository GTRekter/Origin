using Microsoft.Extensions.Configuration;
using System.IO;

namespace Origin
{
    public static class ConfigurationManager
    {
        public static string GetConfigurationByPath(string path)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfigurationRoot Configuration; Configuration = builder.Build();

            return Configuration.GetValue<string>(path);
        }
    }
}
