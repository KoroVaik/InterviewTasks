using Microsoft.Extensions.Configuration;

namespace Core
{
    public static class ConfigurationManager
    {
        private static string SettingsFileName = "settings.json";

        public static T Get<T>() where T : class
        {
            return GetConfiguration().Get<T>();
        }

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(SettingsFileName);

            return builder.Build();
        }
    }
}
