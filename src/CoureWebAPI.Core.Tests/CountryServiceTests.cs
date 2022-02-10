using CoureWebAPI.Core.Helpers;
using CoureWebAPI.Core.Services.Country.Config;
using CoureWebAPI.Core.Services.Country.Services;
using CoureWebAPI.Core.Services.DataRepository.Interface;
using CoureWebAPI.Data.Entities;
using CoureWebAPI.Data.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CoureWebAPI.Core.Tests
{
    public class CountryServiceTests
    {
        private readonly CountryService _countryService;
        private readonly Mock<ICountryRepository> _countryRepositoryMock;

        public CountryServiceTests()
        {
            _countryRepositoryMock = new();
            _countryService = new CountryService(_countryRepositoryMock.Object);
        }

        [Fact]
        public void GetCountryInformation_ShouldReturnCountryInformation_WhenCountryCodeExists()
        {
            var phoneNumber = "2348033432323";
            var response = GetCountry();
            var expectedResponse = new GetCountryResponse()
            {
                Number = phoneNumber,
                Country = PopulateInMemoryCountryData().Where(c => c.CountryCode == Constants.GetCountryCode(phoneNumber)).FirstOrDefault().ToCountryResponse()
            };
            _countryRepositoryMock.Setup(c => c.FindAllAsync(It.IsAny<string>())).Returns(response);

            var result = _countryService.GetCountryInformation(phoneNumber);

            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public void GetCountryInformation_ShouldNotReturnCountryInformation_WhenCountryCodeDoesNotExist()
        {
            var phoneNumber = "5558033432323";
            _countryRepositoryMock.Setup(c => c.FindAllAsync(It.IsAny<string>())).Returns((Country)null);

            var result = _countryService.GetCountryInformation(phoneNumber);

            Assert.Null(result);
        }

        #region PrivateMethods

        private Country GetCountry()
        {
            return new Country()
            {
                Id = 1,
                Name = "Nigeria",
                CountryCode = "234",
                CountryIso = "NG",
                CountryDetails = PopulateInMemoryCountryDetailsData().Where(c => c.CountryId == 1)
            };
        }
        private List<Country> PopulateInMemoryCountryData()
        {
            var _countriesDetails = PopulateInMemoryCountryDetailsData();
            return new List<Country>()
            {
                new Country()
                {
                    Id = 1,
                    Name = "Nigeria",
                    CountryCode = "234",
                    CountryIso = "NG",
                    CountryDetails = _countriesDetails.Where(c => c.CountryId == 1)
                },
                new Country()
                {
                    Id = 2,
                    Name = "Ghana",
                    CountryCode = "233",
                    CountryIso = "GH",
                    CountryDetails = _countriesDetails.Where(c => c.CountryId == 2)
                },
                new Country()
                {
                    Id = 3,
                    Name = "Bening Republic",
                    CountryCode = "229",
                    CountryIso = "BN",
                    CountryDetails = _countriesDetails.Where(c => c.CountryId == 3)
                },
                new Country()
                {
                    Id = 4,
                    Name = "Cote d'Ivoire",
                    CountryCode = "225",
                    CountryIso = "CIV",
                    CountryDetails = _countriesDetails.Where(c => c.CountryId == 4)
                }
            };
        }

        private List<CountryDetails> PopulateInMemoryCountryDetailsData()
        {
            return new List<CountryDetails>()
            {
                new CountryDetails()
                {
                    Id = 1,
                    CountryId = 1,
                    Operator = "MTN Nigeria",
                    OperatorCode = "MTN NG"
                },
                new CountryDetails()
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
        }
        #endregion
    }
}