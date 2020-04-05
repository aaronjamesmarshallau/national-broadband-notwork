using System;

namespace Notwork.Worker.Configuration
{
    public partial class EnvironmentConfig
    {
        private static Lazy<EnvironmentConfig> _instance = new Lazy<EnvironmentConfig>(Load);

        public static EnvironmentConfig Current => _instance.Value;

        private static EnvironmentConfig Load()
        {
            return new EnvironmentConfig
            {
                ApiHost = Environment.GetEnvironmentVariable("API_HOST") ?? "localhost",
                ApiPort = int.Parse(Environment.GetEnvironmentVariable("API_PORT") ?? "5000"),
            };
        }
    }
}