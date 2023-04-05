using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherAPI
{
    public static class DomainServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<GeneralService.MasterReference.IMasterReferenceService, GeneralService.MasterReference.MasterReferenceService>();
            services.AddScoped<WeatherService.Weather.IWeatherService, WeatherService.Weather.WeatherService>();
            return services;
        }
    }
}
