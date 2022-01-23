using BusinessLogic.DTO;
using BusinessLogic.Services.Commands;
using BusinessLogic.Services.Requests;
using CatalogsManager.App.Identity.Services;
using CatalogsManager.Aspects.Logging;
using ExtensionServiceInstaller;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace CatalogsManager.Installers
{
    public class ServicesInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(selector => selector
                .FromAssemblyOf<CatalogDTO>()
                    .AddClasses(classes => classes
                        .AssignableToAny(typeof(IRequestHandler<,>), typeof(ICommandHandler<>))
                        .Where(type => type.Name.EndsWith("Handler")))
                    .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            services.Decorate(typeof(ICommandHandler<>), typeof(CommandHandlerLogging<>));
            services.Decorate(typeof(IRequestHandler<,>), typeof(RequestHandlerLogging<,>));

            services.AddScoped<IVkAdminService, VkAdminService>();
            services.Decorate<IVkAdminService, VkAdminServiceLogging>();
        }
    }
}
