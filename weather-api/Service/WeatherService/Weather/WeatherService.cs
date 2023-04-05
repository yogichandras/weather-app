using AutoFixture;
using GlobalData.Common;
using GlobalData.Weather;
using System;
using GeneralService.MasterReference;
using GlobalUtil.Common;
using Serilog;

namespace WeatherService.Weather
{
    public class WeatherService : IWeatherService
    {
        private readonly IMasterReferenceService _masterReferenceService;

        public WeatherService(IMasterReferenceService masterReferenceService)
        {
            _masterReferenceService = masterReferenceService;
        }

        public ResponseDto<WeatherDto> GetWeather(int idCity)
        {
            var result = new ResponseDto<WeatherDto>();
            try
            {
                var getCity = _masterReferenceService.GetCity(idCity);
                if (getCity.Result != null)
                {
                    var fixture = new Fixture();
                    var weather = fixture.Create<WeatherDto>();
                    weather.Location = getCity.Result.CityName;
                    weather.FahrenheitTemperature = new Random().Next(30, 100);
                    weather.CelsiusTemperature = weather.FahrenheitTemperature.FahrenheitToCelcius();
                    weather.Time = DateTime.Now;
                    weather.SkyConditions = weather.FahrenheitTemperature.FahrenheitToSkyCondition();
                    result.Result = weather;
                }
                else
                {
                    result.ErrorMessage = "Location not found.";
                }
            }
            catch (Exception e)
            {
                Log.Error(e.InnerException?.Message ?? e.Message);
                result.ErrorMessage = e.Message;
            }

            return result;
        }
    }
}
