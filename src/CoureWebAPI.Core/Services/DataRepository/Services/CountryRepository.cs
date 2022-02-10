using CoureWebAPI.Core.Services.DataRepository.Interface;

namespace CoureWebAPI.Core.Services.DataRepository.Services
{
    public class CountryRepository : IGenericRepository<Data.Entities.Country>, ICountryRepository
    {
        private List<Data.Entities.Country> _countries;
        private List<Data.Entities.CountryDetails> _countriesDetails;
        
        public CountryRepository()
        {            
            PopulateInMemoryCountryData();
        }

        public bool Any(string countryCode)
        {
            return _countries.Any(x => x.CountryCode == Convert.ToInt32(countryCode));
        }
        public Data.Entities.Country FindAllAsync(string countryCode)
        {
            return _countries.FirstOrDefault(x => x.CountryCode == Convert.ToInt32(countryCode));
        }

        private List<Data.Entities.Country> PopulateInMemoryCountryData()
        {
            PopulateInMemoryCountryDetailsData();
            _countries = new List<Data.Entities.Country>()
            {
                new Data.Entities.Country()
                {
                    Id = 1,
                    Name = "Nigeria",
                    CountryCode = 234,
                    CountryIso = "NG",
                    CountryDetails = _countriesDetails.Where(c => c.CountryId == 1)
                },
                new Data.Entities.Country()
                {
                    Id = 2,
                    Name = "Ghana",
                    CountryCode = 233,
                    CountryIso = "GH",
                    CountryDetails = _countriesDetails.Where(c => c.CountryId == 2)
                },
                new Data.Entities.Country()
                {
                    Id = 3,
                    Name = "Bening Republic",
                    CountryCode = 229,
                    CountryIso = "BN",
                    CountryDetails = _countriesDetails.Where(c => c.CountryId == 3)
                },
                new Data.Entities.Country()
                {
                    Id = 4,
                    Name = "Cote d'Ivoire",
                    CountryCode = 225,
                    CountryIso = "CIV",
                    CountryDetails = _countriesDetails.Where(c => c.CountryId == 4)
                }
            };

            return _countries;
        }

        private List<Data.Entities.CountryDetails> PopulateInMemoryCountryDetailsData()
        {            
            _countriesDetails = new List<Data.Entities.CountryDetails>()
            {
                new Data.Entities.CountryDetails()
                {
                    Id = 1,
                    CountryId = 1,
                    Operator = "MTN Nigeria",
                    OperatorCode = "MTN NG"
                },
                new Data.Entities.CountryDetails()
                {
                    Id = 2,
                    CountryId = 1,
                    Operator = "Airtel Nigeria",
                    OperatorCode = "ANG"
                },
                new Data.Entities.CountryDetails()
                {
                    Id = 3,
                    CountryId = 1,
                    Operator = "9 Mobile Nigeria",
                    OperatorCode = "ETN"
                },
                new Data.Entities.CountryDetails()
                {
                    Id = 4,
                    CountryId = 1,
                    Operator = "Globacom Nigeria",
                    OperatorCode = "GLO NG"
                },
                new Data.Entities.CountryDetails()
                {
                    Id = 5,
                    CountryId = 2,
                    Operator = "Vodafone Ghana",
                    OperatorCode = "Vodafone GH"
                },
                new Data.Entities.CountryDetails()
                {
                    Id = 6,
                    CountryId = 2,
                    Operator = "MTN Ghana",
                    OperatorCode = "MTN Ghana"
                },
                new Data.Entities.CountryDetails()
                {
                    Id = 7,
                    CountryId = 2,
                    Operator = "Tigo Ghana",
                    OperatorCode = "Tigo Ghana"
                },
                new Data.Entities.CountryDetails()
                {
                    Id = 8,
                    CountryId = 3,
                    Operator = "MTN Benin",
                    OperatorCode = "MTN Benin"
                },
                new Data.Entities.CountryDetails()
                {
                    Id = 9,
                    CountryId = 3,
                    Operator = "Moov Benin",
                    OperatorCode = "Moov Benin"
                },
                new Data.Entities.CountryDetails()
                {
                    Id = 10,
                    CountryId = 4,
                    Operator = "MTN Cote d'Ivoire",
                    OperatorCode = "MTN CIV"
                }
            };        
            
            return _countriesDetails;
        }
    }
}