using Microsoft.AspNetCore.Mvc;
using netcore_docker_heroku.API.Interfaces;
using netcore_docker_heroku.Models;

namespace netcore_docker_heroku.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                         IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [Produces(typeof(IEnumerable<WeatherForecast>))]
        public IActionResult Get()
        {
            try
            {
                var result = this._weatherForecastService.GetWeathers();

                if (result is null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}