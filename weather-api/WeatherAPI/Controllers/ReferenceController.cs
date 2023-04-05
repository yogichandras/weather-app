using GeneralService.MasterReference;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("api/reference")]
    public class ReferenceController : ControllerBase
    {
        private readonly IMasterReferenceService _referenceService;
        public ReferenceController(IMasterReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        [HttpGet("countries")]
        public IActionResult ListCountries()
        {
            var result = _referenceService.ListCountries();
            if (string.IsNullOrEmpty(result.ErrorMessage))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("cities")]
        public IActionResult ListCities(int idCountry)
        {
            var result = _referenceService.ListCities(idCountry);
            if (string.IsNullOrEmpty(result.ErrorMessage))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
