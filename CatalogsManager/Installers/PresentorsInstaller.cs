using CatalogManager.ViewModels;
using CatalogManager.Presentors;
using CatalogManager.Presentors.CatalogsPresentors;
using CatalogManager.Presentors.Requests;
using CatalogManager.Presentors.TitlesGroupsPresentors;
using ExtensionServiceInstaller;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CatalogManager.Installers
{
    public class PresentorsInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services)
        {
            services.AddScoped<IPresentor<IEnumerable<CatalogViewModel>, GetAllCatalogs>, 
                CatalogsOrderByPresentor>();
            services.AddScoped<IPresentor<IEnumerable<TitlesGroupViewModel>, GetTitlesGroupsByCatalogId>, 
                TitlesGroupsOrderByPresentor>();
        }
    }
}
