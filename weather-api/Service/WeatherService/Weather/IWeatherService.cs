using GlobalData.Common;
using GlobalData.Weather;

namespace WeatherService.Weather
{
    public interface IWeatherService
    {
        ResponseDto<WeatherDto> GetWeather(int idCity);
    }
}
