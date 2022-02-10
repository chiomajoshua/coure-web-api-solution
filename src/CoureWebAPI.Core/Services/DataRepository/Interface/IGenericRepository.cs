using CoureWebAPI.Core.Helpers.Autofac;

namespace CoureWebAPI.Core.Services.DataRepository.Interface
{
    public interface IGenericRepository<T> : IAutoDependencyCore
    { 
        /// <summary>
        /// Gets All Data For an Entity
        /// </summary>
        /// <param name="searchParameter"></param>
        /// <returns></returns>
        T FindAllAsync(string searchParameter);

        /// <summary>
        /// Confirms data exists
        /// </summary>
        /// <param name="searchParameter"></param>
        /// <returns></returns>
        bool Any(string searchParameter);
    }
}