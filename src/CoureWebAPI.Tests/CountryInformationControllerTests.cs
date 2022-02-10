using CoureWebAPI.Controllers;
using CoureWebAPI.Core.Helpers;
using CoureWebAPI.Core.Services.Country.Config;
using CoureWebAPI.Core.Services.Country.Interface;
using CoureWebAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CoureWebAPI.Tests
{
    public class CountryInformationControllerTests
    {
        private readonly CountryInformationController _countryInformationController;
        private readonly Mock<ICountryService> _countryServiceMock;

        public CountryInformationControllerTests()
        {
            _countryServiceMock = new();
            _countryInformationController = new(_countryServiceMock.Object);
        }

        [Fact]
        public void GetCountryDetails_ShouldReturnOk_WhenCountryCodeExists()
        {
            var phoneNumber = "2348033432323";
            var response = new GetCountryResponse()
            {
                Number = phoneNumber,
                Country = PopulateInMemoryCountryData().Where(c => c.CountryCode == Constants.GetCountryCode(phoneNumber)).FirstOrDefault().ToCountryResponse()
            };
            _countryServiceMock.Setup(c => c.GetCountryInformation(It.IsAny<string>())).Returns(response);

            var result = _countryInformationController.Get(phoneNumber) as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetCountryDetails_ShouldReturnNotFound_WhenCountryCodeDoesNotExists()
        {
            var phoneNumber = "5558033432323";

            _countryServiceMock.Setup(c => c.GetCountryInformation(It.IsAny<string>())).Returns((GetCountryResponse)null);

            var result = _countryInformationController.Get(phoneNumber) as NotFoundObjectResult;
            Assert.Equal(404, result.StatusCode);
        }


        #region PrivateMethods
        private List<Data.Entities.Country> PopulateInMemoryCountryData()
        {
            var _countriesDetails = PopulateInMemoryCountryDetailsData();
            return new List<Data.Entities.Country>()
            {
                new Data.Entities.Country()
                {
                    Id = 1,
                    Name = "Nigeria",
                    CountryCode = "234",
                    CountryIso = "NG",
                    CountryDetails = _countriesDetails.Where(c => c.CountryId == 1)
                },
                new Data.Entities.Country()
                {
                    Id = 2,
                    Name = "Ghana",
                    CountryCode = "233",
                    CountryIso = "GH",
                    CountryDetails = _countriesDetails.Where(c => c.CountryId == 2)
                },
                new Data.Entities.Country()
                {
                    Id = 3,
                    Name = "Bening Republic",
                    CountryCode = "229",
                    CountryIso = "BN",
                    CountryDetails = _countriesDetails.Where(c => c.CountryId == 3)
                },
                new Data.Entities.Country()
                {
                    Id = 4,
                    Name = "Cote d'Ivoire",
                    CountryCode = "225",
                    CountryIso = "CIV",
                    CountryDetails = _countriesDetails.Where(c => c.CountryId == 4)
                }
            };
        }

        private List<Data.Entities.CountryDetails> PopulateInMemoryCountryDetailsData()
        {
            return new List<Data.Entities.CountryDetails>()
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
        }
        #endregion
    }
}