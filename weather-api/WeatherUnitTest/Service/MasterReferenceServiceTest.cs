using GeneralService.MasterReference;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using WeatherAPI;

namespace WeatherUnitTest.Service
{
    public class MasterReferenceServiceTest
    {
        private IMasterReferenceService _masterReferenceService;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddDomainServices();

            var serviceProvider = services.BuildServiceProvider();
            _masterReferenceService = serviceProvider.GetService<IMasterReferenceService>();
        }

        [Test]
        public void GetAllCountries_should_success()
        {
            var getAllCountries = _masterReferenceService.ListCountries();
            Assert.NotNull(getAllCountries);
            Assert.NotNull(getAllCountries.Result);
            Assert.Null(getAllCountries.ErrorMessage);
            Assert.AreEqual(2, getAllCountries.Result.Count);
        }

        [Test]
        public void GetCitiesFromExistingCountry_should_success()
        {
            var getAllCities = _masterReferenceService.ListCities(1);
            Assert.NotNull(getAllCities);
            Assert.NotNull(getAllCities.Result);
            Assert.Null(getAllCities.ErrorMessage);
            Assert.AreEqual(1, getAllCities.Result.Count);
        }

        [Test]
        public void GetCitiesFromNonExistingCountry_should_return_empty()
        {
            var getAllCities = _masterReferenceService.ListCities(3);
            Assert.NotNull(getAllCities);
            Assert.IsEmpty(getAllCities.Result);
            Assert.Null(getAllCities.ErrorMessage);
        }

        [Test]
        public void GetExistingCity_should_success()
        {
            var getCity = _masterReferenceService.GetCity(1);
            Assert.NotNull(getCity);
            Assert.NotNull(getCity.Result);
            Assert.Null(getCity.ErrorMessage);
        }

        [Test]
        public void GetNonExistingCity_should_return_null()
        {
            var getCity = _masterReferenceService.GetCity(3);
            Assert.NotNull(getCity);
            Assert.Null(getCity.Result);
            Assert.Null(getCity.ErrorMessage);
        }
    }
}