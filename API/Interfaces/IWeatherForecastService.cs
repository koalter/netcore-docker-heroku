using netcore_docker_heroku.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netcore_docker_heroku.API.Interfaces
{
    public interface IWeatherForecastService
    {
        WeatherForecast[] GetWeathers();
        Task<List<WeatherForecast>> GetWeathersAsync();
    }
}
