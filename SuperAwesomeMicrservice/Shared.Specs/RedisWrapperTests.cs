using NUnit.Framework;
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
            RedisWrapper redisWrapper = new RedisWrapper();
            var key = Guid.NewGuid().ToString();
            var body = "Super cool text";
            await redisWrapper.SaveAsync(key, body).ConfigureAwait(false);
            var getResult = await redisWrapper.GetAsync(key).ConfigureAwait(false);

            Assert.That(getResult, Is.EqualTo(body));
        }
    }
}
