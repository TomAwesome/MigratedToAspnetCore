using Moq;
using NUnit.Framework;
using Shared.Configuration;
using Shared.Redis;
using System;
using System.Threading.Tasks;

namespace Shared.Specs
{
    [TestFixture]
    public class RedisWrapperTests
    {
        [Test]
        public async Task Save_and_get_Test()
        {
            var redisSettingsMock = new Mock<IRedisSettings>();
            redisSettingsMock.Setup(settings => settings.RedisAddress).Returns("localhost");
            RedisWrapper redisWrapper = new RedisWrapper(redisSettingsMock.Object);
            var key = Guid.NewGuid().ToString();
            var body = "Super cool text";
            await redisWrapper.SaveAsync(key, body).ConfigureAwait(false);
            var getResult = await redisWrapper.GetAsync(key).ConfigureAwait(false);

            Assert.That(getResult, Is.EqualTo(body));
        }
    }
}
