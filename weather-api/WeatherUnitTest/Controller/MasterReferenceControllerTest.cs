using AutoFixture;
using GeneralService.MasterReference;
using GlobalData.Common;
using GlobalData.Reference;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using WeatherAPI.Controllers;

namespace WeatherUnitTest.Controller
{
    public class MasterReferenceControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllCountries_should_success()
        {
            var mockService = new Mock<IMasterReferenceService>();
            var fixture = new Fixture();
            var countries = fixture.Create<IList<CountryDto>>();
            mockService.Setup(x => x.ListCountries()).Returns(new ResponseDto<IList<CountryDto>>
            {
                Result = countries
            });

            var controller = new ReferenceController(mockService.Object);
            var getAllCountries = controller.ListCountries() as OkObjectResult;
            Assert.NotNull(getAllCountries);

            var result = getAllCountries.Value as ResponseDto<IList<CountryDto>>;
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.Null(result.ErrorMessage);
        }

        [Test]
        public void GetCitiesFromExistingCountry_should_success()
        {
            var mockService = new Mock<IMasterReferenceService>();
            var fixture = new Fixture();
            var cities = fixture.Create<IList<CityDto>>();
            mockService.Setup(x => x.ListCities(1)).Returns(new ResponseDto<IList<CityDto>>
            {
                Result = cities
            });

            var controller = new ReferenceController(mockService.Object);
            var getAllCities = controller.ListCities(1) as OkObjectResult;
            Assert.NotNull(getAllCities);

            var result = getAllCities.Value as ResponseDto<IList<CityDto>>;
            
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.Null(result.ErrorMessage);
        }

        [Test]
        public void GetCitiesFromNonExistingCountry_should_return_empty()
        {
            var mockService = new Mock<IMasterReferenceService>();
            mockService.Setup(x => x.ListCities(1)).Returns(new ResponseDto<IList<CityDto>>
            {
                Result = new List<CityDto>()
            });

            var controller = new ReferenceController(mockService.Object);
            var getAllCities = controller.ListCities(1) as OkObjectResult;
            Assert.NotNull(getAllCities);

            var result = getAllCities.Value as ResponseDto<IList<CityDto>>;
            
            Assert.NotNull(result);
            Assert.IsEmpty(result.Result);
            Assert.Null(result.ErrorMessage);
        }
    }
}