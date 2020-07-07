using System;
using System.Configuration;

namespace Shared.Configuration
{
    public class Settings : ISettings
    {
        public string GetOptionalSetting(string name)
        {
            return ConfigurationManager.AppSettings.Get(name);
        }

        public string GetRequiredSetting(string name)
        {
            var value = ConfigurationManager.AppSettings.Get(name);

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception($"missing setting key: {name}");
            }
            return value;
        }
    }

    public interface ISettings
    {
        string GetOptionalSetting(string name);
        string GetRequiredSetting(string name);
    }
}
