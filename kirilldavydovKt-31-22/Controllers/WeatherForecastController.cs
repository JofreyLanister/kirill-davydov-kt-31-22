using Microsoft.AspNetCore.Mvc;
using NLog;

namespace kirilldavydovKt_31_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            logger.Error("Вызван метод GET у WeatherForecastController");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> Post([FromBody] string newSummary)
        {
            logger.Error($"Вызван метод POST. Получено новое описание: {newSummary}");

            var tempSummaries = Summaries.Append(newSummary).ToArray();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = tempSummaries[Random.Shared.Next(tempSummaries.Length)]
            })
            .ToArray();
        }
    }
}