using Shared.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SuperAwesomeMicrservice.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IRedisWrapper redisWrapper;

        public ValuesController(IRedisWrapper redisWrapper)
        {
            this.redisWrapper = redisWrapper;
        }

        // GET api/values/5
        public async Task<string> Get([FromUri]string id)
        {
            var result = await redisWrapper.GetAsync(id);
            if(string.IsNullOrEmpty(result))
            {
                return $"There is no value in redis for this key: {id}";
            }
            return result;
        }

        // POST api/values
        public async Task Post([FromUri]string id, [FromBody] string value)
        {
            await redisWrapper.SaveAsync(id, value);
        }
    }
}
