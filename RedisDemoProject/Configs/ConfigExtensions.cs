using StackExchange.Redis;

namespace RedisDemoProject.Configs
{
    public static class ConfigExtensions
    {
        public static void AddRedis(this WebApplicationBuilder builder)
        {
            var host = builder.Configuration.GetValue<string>("RedisConnection:Host");
            var port = builder.Configuration.GetValue<int>("RedisConnection:Port");
            var endPoints = $"{host}:{port}";

            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { endPoints },
                Ssl = true,
                AllowAdmin = true,
                ConnectTimeout = 30000,
                ResponseTimeout= 30000,
                AbortOnConnectFail = false,
                ConnectRetry =3

            };

            builder.Services.AddSingleton<IConnectionMultiplexer>(conf =>
                                          ConnectionMultiplexer.Connect(configurationOptions));
        }
    }
}
