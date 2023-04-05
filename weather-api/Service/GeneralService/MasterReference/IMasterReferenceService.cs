using GlobalData.Common;
using GlobalData.Reference;
using System.Collections.Generic;

namespace GeneralService.MasterReference
{
    public interface IMasterReferenceService
    {
        ResponseDto<IList<CountryDto>> ListCountries();
        ResponseDto<IList<CityDto>> ListCities(int idCountry);
        ResponseDto<CityDto> GetCity(int idCity);
    }
}
