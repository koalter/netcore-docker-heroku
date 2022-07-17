using netcore_docker_heroku.API.Interfaces;
using netcore_docker_heroku.API.Services;

namespace netcore_docker_heroku.API.Extensions
{
    public static class InjectionExtension
    {
        public static void AddInjections(this IServiceCollection services)
        {
            services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
        }
    }
}
