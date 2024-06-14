using LoremIpsum.Domain.Interfaces.Services;
using LoremIpsum.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LoremIpsum.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IClienteService, ClienteService>();
        }
    }
}
