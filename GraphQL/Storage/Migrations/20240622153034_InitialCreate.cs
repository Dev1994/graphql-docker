using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TemperatureC = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.Sql(@"
DECLARE @i int = 0;
WHILE @i < 50
BEGIN
    INSERT INTO WeatherForecasts (Id, Date, TemperatureC, Summary)
    VALUES (NEWID(), DATEADD(day, @i, GETDATE()), ROUND((RAND() * 40) - 10, 0), 
    CASE 
        WHEN @i % 5 = 0 THEN 'Freezing'
        WHEN @i % 5 = 1 THEN 'Bracing'
        WHEN @i % 5 = 2 THEN 'Chilly'
        WHEN @i % 5 = 3 THEN 'Cool'
        WHEN @i % 5 = 4 THEN 'Mild'
        ELSE 'Warm'
    END)
    SET @i = @i + 1;
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
