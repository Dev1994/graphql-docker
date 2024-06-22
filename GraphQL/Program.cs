using GraphQL.GraphQL;
using GraphQL.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

// Read the connection string from the appsettings.json file
builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddDbContext<GraphQlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GraphQLDatabase")));

var app = builder.Build();

// Run database migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GraphQlDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// I know this isn't what you'd do in production, but it's a quick way to get started with testing and development
// {
app.UseSwagger();
app.UseSwaggerUI();
app.MapGraphQL();
// }

app.UseAuthorization();

app.MapControllers();

app.Run();