using CoureWebAPI.Data.Models;

namespace CoureWebAPI.Core.Services.Country.Config
{
    public static class CountryExtensions
    {
        public static CountryResponse ToCountryResponse(this Data.Entities.Country country)
        {
            var countryDetailsResponse = new List<CountryDetailsResponse>();
            countryDetailsResponse.AddRange(country.CountryDetails.Select(x => new CountryDetailsResponse()
            {
                 Operator = x.Operator,
                 OperatorCode = x.OperatorCode,
            }));


            return new CountryResponse
            {
                CountryCode = country.CountryCode.ToString(),
                Name = country.Name,
                CountryIso = country.CountryIso,
                 CountryDetails = countryDetailsResponse
            };
        }
    }
}