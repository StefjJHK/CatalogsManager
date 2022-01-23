using AutoMapper;
using DataAccess.Data;
using ExtensionServiceInstaller;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogsManager.Installers
{
    public class UtilityInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            var mapper = new MapperConfiguration(config => 
                    config.AddMaps(typeof(AppDbContext), typeof(Startup)))
                .CreateMapper();

            services.AddSingleton(services => mapper);
        }
    }
}
