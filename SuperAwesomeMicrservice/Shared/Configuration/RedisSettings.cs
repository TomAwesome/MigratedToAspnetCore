namespace Shared.Configuration
{
    public class RedisSettings : IRedisSettings
    {
        private readonly ISettings settings;

        public RedisSettings(ISettings settings)
        {
            this.settings = settings;
        }

        public string RedisAddress => settings.GetRequiredSetting(nameof(RedisAddress));
    }

    public interface IRedisSettings
    {
        string RedisAddress { get; }
    }
}
