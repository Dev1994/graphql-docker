using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Storage;

public class GraphQlDbContext : DbContext
{
    public GraphQlDbContext(DbContextOptions<GraphQlDbContext> options) : base(options)
    {
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; } = default!;
}