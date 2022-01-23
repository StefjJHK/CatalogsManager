using CatalogsManager.App.Identity;
using CatalogsManager.App.Identity.RequirementHandlers;
using CatalogsManager.App.Identity.Requirements;
using CatalogsManager.App.Identity.Services;
using ExtensionServiceInstaller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogsManager.Installers
{
    public class IdentityInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            var identityOptions = new DbContextOptionsBuilder<AppIdentityDbContext>()
                .UseSqlServer(configuration.GetConnectionString("User"))
                .Options;

            services.AddDefaultIdentity<User>()
               .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "AllowedEditCatalogs",
                    policyBuilder => policyBuilder.AddRequirements(
                        new AllowedEditCatalogsRequirement()));
            });

            services.AddAuthentication()
                .AddVkontakte(options =>
                {
                    options.ClientId = configuration["VkClient:Id"];
                    options.ClientSecret = configuration["VkClient:Secret"];
                });

            services.AddScoped(services => new AppIdentityDbContext(identityOptions));
            services.AddScoped<IAuthorizationHandler, VkAdminHandler>();
        }
    }
}
