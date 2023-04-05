using System;
using System.Collections.Generic;
using System.Linq;
using GlobalData.Common;
using GlobalData.Reference;
using Serilog;

namespace GeneralService.MasterReference
{
    public class MasterReferenceService : IMasterReferenceService
    {
        private readonly IList<CountryDto> _countryData = new List<CountryDto>()
        {
            new CountryDto()
            {
                IdCountry = 1,
                CountryName = "Indonesia"
            },
            new CountryDto()
            {
                IdCountry = 2,
                CountryName = "Australia"
            }
        };

        private readonly IList<CityDto> _cityData = new List<CityDto>()
        {
            new CityDto()
            {
                IdCity = 1,
                IdCountry = 1,
                CityName = "Jakarta"
            },
            new CityDto()
            {
                IdCity = 2,
                IdCountry = 2,
                CityName = "Melbourne"
            }
        };

        public ResponseDto<IList<CountryDto>> ListCountries()
        {
            var result = new ResponseDto<IList<CountryDto>>();
            try
            {
                result.Result = _countryData;
            }
            catch (Exception e)
            {
                Log.Error(e.InnerException?.Message ?? e.Message);
                result.ErrorMessage = e.Message;
            }
            return result;
        }

        public ResponseDto<IList<CityDto>> ListCities(int idCountry)
        {
            var result = new ResponseDto<IList<CityDto>>();
            try
            {
                result.Result = _cityData.Where(x => x.IdCountry == idCountry).ToList();
            }
            catch (Exception e)
            {
                Log.Error(e.InnerException?.Message ?? e.Message);
                result.ErrorMessage = e.Message;
            }
            return result;
        }

        public ResponseDto<CityDto> GetCity(int idCity)
        {
            var result = new ResponseDto<CityDto>();
            try
            {
                result.Result = _cityData.FirstOrDefault(x => x.IdCity == idCity);
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
