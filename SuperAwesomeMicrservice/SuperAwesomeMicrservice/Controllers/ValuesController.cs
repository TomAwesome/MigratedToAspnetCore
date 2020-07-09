using AwesomeLogger;
using Shared.Redis;
using System.Threading.Tasks;
using System.Web.Http;

namespace SuperAwesomeMicrservice.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IRedisWrapper redisWrapper;
        private readonly ILogger logger;

        public ValuesController(IRedisWrapper redisWrapper, ILogger logger)
        {
            this.redisWrapper = redisWrapper;
            this.logger = logger;
        }

        public async Task<string> Get([FromUri]string id)
        {
            logger.Info($"getting value for key: {id}");
            var result = await redisWrapper.GetAsync(id);
            if(string.IsNullOrEmpty(result))
            {
                return $"There is no value in redis for this key: {id}";
            }
            return result;
        }

        public async Task<IHttpActionResult> Post([FromUri]string id, [FromBody] string value)
        {
            logger.Info($"setting value for key: {id} value: {value}");
            await redisWrapper.SaveAsync(id, value);
            return Ok();
        }
    }
}
