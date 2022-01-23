using CatalogsManager.ViewModels;
using CatalogsManager.Presentors;
using CatalogsManager.Presentors.CatalogsPresentors;
using CatalogsManager.Presentors.Requests;
using CatalogsManager.Presentors.TitlesGroupsPresentors;
using ExtensionServiceInstaller;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace CatalogsManager.Installers
{
    public class PresentorsInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPresentor<IEnumerable<CatalogViewModel>, GetAllCatalogs>, 
                CatalogsOrderByPresentor>();
            services.AddScoped<IPresentor<IEnumerable<TitlesGroupViewModel>, GetTitlesGroupsByCatalogId>, 
                TitlesGroupsOrderByPresentor>();
        }
    }
}
