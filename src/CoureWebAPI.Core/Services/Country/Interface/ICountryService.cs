using CoureWebAPI.Core.Helpers.Autofac;
using CoureWebAPI.Data.Models;

namespace CoureWebAPI.Core.Services.Country.Interface
{
    public interface ICountryService : IAutoDependencyCore
    {
        /// <summary>
        /// Get Country Information From Phone Number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        GetCountryResponse GetCountryInformation(string phoneNumber);
    }
}