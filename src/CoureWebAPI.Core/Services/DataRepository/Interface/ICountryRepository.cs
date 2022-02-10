using CoureWebAPI.Core.Helpers.Autofac;

namespace CoureWebAPI.Core.Services.DataRepository.Interface
{
    public interface ICountryRepository : IGenericRepository<Data.Entities.Country>, IAutoDependencyCore { }
}