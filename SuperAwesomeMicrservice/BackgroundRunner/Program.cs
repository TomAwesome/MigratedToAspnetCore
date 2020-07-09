using Shared.DependencyInjection;
using Shared.Redis;
using StructureMap;
using System;
using System.Threading.Tasks;

namespace BackgroundRunner
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IContainer container = new Container(config =>
            {
                config.AddRegistry<SharedRegistry>();
            });
            var redisWrapper = container.GetInstance<IRedisWrapper>();
            while(true)
            {
                await redisWrapper.SaveAsync("helloworld2", DateTimeOffset.UtcNow.ToString()).ConfigureAwait(false);
                await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            }

        }
    }
}
