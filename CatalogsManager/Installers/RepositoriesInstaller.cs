using BusinessLogic.Repositories;
using CatalogManager.App.Identity;
using DataAccess.Data;
using DataAccess.Repositories;
using ExtensionServiceInstaller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogManager.Installers
{
    public class RepositoriesInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services)
        {
            var identityOptions = new DbContextOptionsBuilder<AppIdentityDbContext>()
                .UseSqlite("Data Source=E:\\Desktop\\CatalogsWeb\\CatalogsUsers.db")
                .Options;
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Data Source=E:\\Desktop\\CatalogsWeb\\Catalogs.db")
                .Options;

            services.AddSingleton(services => new AppIdentityDbContext(identityOptions));
            services.AddSingleton(services => new AppDbContext(options));

            services.AddSingleton<ICatalogsRepository, CatalogsRepository>();
            services.AddSingleton<ITitlesRepository, TitlesRepository>();
        }
    }
}
