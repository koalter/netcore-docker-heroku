using netcore_docker_heroku.Models;

namespace netcore_docker_heroku.API.Interfaces
{
    public interface IWeatherForecastService
    {
        WeatherForecast[] GetWeathers();
        Task<List<WeatherForecast>> GetWeathersAsync();
    }
}
