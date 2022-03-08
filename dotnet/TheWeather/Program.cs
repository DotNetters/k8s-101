var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", async () =>
{
    async IAsyncEnumerable<WeatherForecast> StreamWeatherForecastAsync()
    {
        for (int i = 0; i < 8; i++)
        {
            // await Task.Delay(Random.Shared.Next(30, 90) * 1000);
            yield return new WeatherForecast(
                DateTime.Now.AddDays(i),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]);
        }

    }
    return StreamWeatherForecastAsync();
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}