using GraphQL.Entities;
using GraphQL.Storage;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly GraphQlDbContext _dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, GraphQlDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("Getting weather forecast");
            return _dbContext.WeatherForecasts;
        }
    }
}
