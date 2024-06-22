using GraphQL.Entities;
using GraphQL.Storage;

namespace GraphQL.GraphQL;

public class Query
{
    public IQueryable<WeatherForecast> GetWeatherForecast([Service] GraphQlDbContext dbContext)
    {
        return dbContext.WeatherForecasts;
    }
}