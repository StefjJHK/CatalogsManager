using AutoMapper;
using DataAccess.Data;
using ExtensionServiceInstaller;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogManager.Installers
{
    public class UtilityInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config => 
                    config.AddMaps(typeof(AppDbContext), typeof(Startup)))
                .CreateMapper();

            services.AddSingleton(services => mapper);
        }
    }
}
