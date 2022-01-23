using BusinessLogic.Services.Abstractions.Commands;
using BusinessLogic.Services.Abstractions.Requests;
using BusinessLogic.Services.Implementation.Commands;
using BusinessLogic.Services.Implementation.Requests;
using ExtensionServiceInstaller;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogManager.Installers
{
    public class ServicesInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services)
        {
            services.AddScoped<ICatalogsCommandsService, CatalogsCommandsService>();
            services.AddScoped<ITitlesCommandsService, TitlesCommandsService>();
            services.AddScoped<ICatalogsRequestsService, CatalogsRequestsService>();
            services.AddScoped<ITitlesRequestsService, TitlesRequestsService>();
        }
    }
}
