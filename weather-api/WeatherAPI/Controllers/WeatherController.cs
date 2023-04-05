using Microsoft.AspNetCore.Mvc;
using WeatherService.Weather;

namespace WeatherAPI.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("city")]
        public IActionResult GetCityWeather(int idCity)
        {
            var result = _weatherService.GetWeather(idCity);
            if (string.IsNullOrEmpty(result.ErrorMessage))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
