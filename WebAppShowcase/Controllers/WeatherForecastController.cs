using Microsoft.AspNetCore.Mvc;

namespace WebAppShowcase.Controllers
{
    [ApiController]
    [Route("[controller]")]
#pragma warning disable CS9113 // Parameter is unread.
    public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
#pragma warning restore CS9113 // Parameter is unread.
    {

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get() => "Sunny";
    }
}
