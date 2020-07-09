using System.Collections.Generic;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Examples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILog log4NetLogger;
        private readonly IRandomForecastGenerator randomForecastGenerator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRandomForecastGenerator randomForecastGenerator)
        {
            _logger = logger;
            log4NetLogger = LogManager.GetLogger(typeof(WeatherForecastController));
            this.randomForecastGenerator = randomForecastGenerator;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            log4NetLogger.Info("Get random forcast");
            return randomForecastGenerator.CreateForecast();
        }
    }
}
