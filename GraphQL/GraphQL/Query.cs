using GraphQL.Controllers;
using GraphQL.Entities;
using GraphQL.Storage;

namespace GraphQL.GraphQL;

public class Query
{
    public IQueryable<WeatherForecast> GetWeatherForecast([Service] ILogger<WeatherForecastController> logger,
        [Service] GraphQlDbContext dbContext)
    {
        try
        {
            logger.LogInformation("Getting weather forecast but via freaking graphql man! And via EF Core this time");
            return dbContext.WeatherForecasts;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while getting the weather forecast.");
            throw;
        }
    }
}