using GlobalUtil.Common;
using NUnit.Framework;
using System;
using AutoFixture;
using GlobalData.Common;
using GlobalData.Weather;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WeatherAPI;
using WeatherAPI.Controllers;
using WeatherService.Weather;

namespace WeatherUnitTest.Controller
{
    public class WeatherServiceControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetWeatherFromExistingCity_should_success()
        {
            var mockService = new Mock<IWeatherService>();
            var fixture = new Fixture();
            var weather = fixture.Create<WeatherDto>();
            mockService.Setup(x => x.GetWeather(1)).Returns(new ResponseDto<WeatherDto>
            {
                Result = weather
            });

            var controller = new WeatherController(mockService.Object);
            var getWeather = controller.GetCityWeather(1) as OkObjectResult;
            Assert.NotNull(getWeather);

            var result = getWeather.Value as ResponseDto<WeatherDto>;
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.Null(result.ErrorMessage);
        }

        [Test]
        public void GetWeatherFromNonExistingCity_should_return_error()
        {

            var mockService = new Mock<IWeatherService>();
            var fixture = new Fixture();
            mockService.Setup(x => x.GetWeather(3)).Returns(new ResponseDto<WeatherDto>
            {
                ErrorMessage = "Location not found."
            });

            var controller = new WeatherController(mockService.Object);
            var getWeather = controller.GetCityWeather(3) as BadRequestObjectResult;
            Assert.NotNull(getWeather);

            var result = getWeather.Value as ResponseDto<WeatherDto>;
            
            Assert.NotNull(result);
            Assert.Null(result.Result);
            Assert.NotNull(result.ErrorMessage);
            Assert.AreEqual("Location not found.", result.ErrorMessage);
        }

        [Test]
        public void CheckWeatherValue_should_valid()
        {

            var mockService = new Mock<IWeatherService>();
            var fixture = new Fixture();
            var weather = fixture.Create<WeatherDto>();
            weather.Location = "Jakarta";
            weather.FahrenheitTemperature = new Random().Next(30, 100);
            weather.CelsiusTemperature = weather.FahrenheitTemperature.FahrenheitToCelcius();
            
            mockService.Setup(x => x.GetWeather(1)).Returns(new ResponseDto<WeatherDto>
            {
                Result = weather
            });

            var controller = new WeatherController(mockService.Object);
            var getWeather = controller.GetCityWeather(1) as OkObjectResult;
            Assert.NotNull(getWeather);

            var result = getWeather.Value as ResponseDto<WeatherDto>;
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.Null(result.ErrorMessage);
            Assert.AreEqual("Jakarta", result.Result.Location);
            Assert.AreNotEqual(DateTime.MinValue, result.Result.Time);
            Assert.NotNull(result.Result.Wind);
            // check celsius conversion
            Assert.AreEqual(result.Result.FahrenheitTemperature.FahrenheitToCelcius(), result.Result.CelsiusTemperature);
        }
    }
}
