using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using netcore_docker_heroku.API.Interfaces;
using netcore_docker_heroku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
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

        [HttpGet]
        [Route("async")]
        [Produces(typeof(IEnumerable<WeatherForecast>))]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await this._weatherForecastService.GetWeathersAsync();

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
