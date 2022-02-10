using CoureWebAPI.Core.Services.Country.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CoureWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryInformationController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryInformationController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet, Route("getcountrydetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) return BadRequest("Request is empty");

            var response = _countryService.GetCountryInformation(phoneNumber);
            if(response != null)
                return Ok(response);

            return NotFound("Country Information Not Found");
        }
    }
}