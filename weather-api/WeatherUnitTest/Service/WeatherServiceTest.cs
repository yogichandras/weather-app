using GlobalUtil.Common;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using WeatherAPI;
using WeatherService.Weather;

namespace WeatherUnitTest.Service
{
    public class WeatherServiceTest
    {
        private IWeatherService _weatherService;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddDomainServices();

            var serviceProvider = services.BuildServiceProvider();
            _weatherService = serviceProvider.GetService<IWeatherService>();
        }

        [Test]
        public void GetWeatherFromExistingCity_should_success()
        {
            var getWeather = _weatherService.GetWeather(1);
            Assert.NotNull(getWeather);
            Assert.NotNull(getWeather.Result);
            Assert.Null(getWeather.ErrorMessage);
        }

        [Test]
        public void GetWeatherFromNonExistingCity_should_return_error()
        {
            var getWeather = _weatherService.GetWeather(3);
            Assert.NotNull(getWeather);
            Assert.Null(getWeather.Result);
            Assert.NotNull(getWeather.ErrorMessage);
            Assert.AreEqual("Location not found.", getWeather.ErrorMessage);
        }

        [Test]
        public void CheckWeatherValue_should_valid()
        {
            var getWeather = _weatherService.GetWeather(1);
            Assert.NotNull(getWeather);
            Assert.NotNull(getWeather.Result);
            Assert.Null(getWeather.ErrorMessage);
            Assert.AreEqual("Jakarta", getWeather.Result.Location);
            Assert.AreNotEqual(DateTime.MinValue, getWeather.Result.Time);
            Assert.NotNull(getWeather.Result.Wind);
            // check celsius conversion
            Assert.AreEqual(getWeather.Result.FahrenheitTemperature.FahrenheitToCelcius(), getWeather.Result.CelsiusTemperature);
        }
    }
}
