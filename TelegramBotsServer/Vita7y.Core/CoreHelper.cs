using Microsoft.Extensions.Configuration;

namespace Vita7y.Core
{
    public static class CoreHelper
    {
        public static T LoadSettings<T>(string path, string sectionName) where T : class, new()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("SqlBotSettings.json");

            var config = builder.Build();

            var appConfig = new T();
            config.GetSection(sectionName).Bind(appConfig);
            return appConfig;
        }
    }
}