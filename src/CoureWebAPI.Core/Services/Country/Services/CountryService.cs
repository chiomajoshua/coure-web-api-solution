using CoureWebAPI.Core.Helpers;
using CoureWebAPI.Core.Services.Country.Config;
using CoureWebAPI.Core.Services.Country.Interface;
using CoureWebAPI.Core.Services.DataRepository.Interface;
using CoureWebAPI.Data.Models;

namespace CoureWebAPI.Core.Services.Country.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public GetCountryResponse GetCountryInformation(string phoneNumber)
        {
            var countryCode = Constants.GetCountryCode(phoneNumber);
            if (!_countryRepository.Any(countryCode))
                return null;

            var response = _countryRepository.FindAllAsync(countryCode);
            return new GetCountryResponse { Number = phoneNumber, Country = response.ToCountryResponse() };
        }
    }
}