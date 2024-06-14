using LoremIpsum.Data.Context;
using LoremIpsum.Data.Repository;
using LoremIpsum.Domain.Interfaces;
using LoremIpsum.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoremIpsum.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IClienteRepository, ClienteRepository>();

            serviceCollection.AddDbContext<LoremIpsumContext>(options => options.UseSqlServer(configuration.GetConnectionString("db_connection")));
        }
    }
}
