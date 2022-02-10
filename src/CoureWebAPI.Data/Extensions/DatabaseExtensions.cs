using CoureWebAPI.Data.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CoureWebAPI.Data.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection RegisterDatabaseService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<CoureWebDbContext>(options => options.UseInMemoryDatabase("CoureDb"));
            return serviceCollection;
        }
    }
}