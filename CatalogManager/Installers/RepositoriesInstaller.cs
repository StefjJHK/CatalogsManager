using BusinessLogic.Repositories;
using CatalogsManager.App.Identity;
using CatalogsManager.App.Identity.Repositories;
using DataAccess.Data;
using DataAccess.Repositories;
using ExtensionServiceInstaller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogsManager.Installers
{
    public class RepositoriesInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Catalog"))
                .Options;

            services.AddScoped(services => new AppDbContext(options));
            services.AddScoped<ICatalogsRepository, CatalogsRepository>();
            services.AddScoped<ITitlesRepository, TitlesRepository>();

            services.AddScoped(services => services.GetRequiredService<AppIdentityDbContext>().UserLogins);
            services.AddScoped<IVkAdminsRepository, VkAdminsRepository>();
        }
    }
}
