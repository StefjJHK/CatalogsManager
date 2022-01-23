using CatalogManager.Resources.FluentValidation;
using ExtensionServiceInstaller;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace CatalogManager.Installers
{
    public class AppInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services)
        {
            services
                .AddLocalization(options => options.ResourcesPath = "Resources")
                .AddRazorPages()
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<Startup>();
                    options.ImplicitlyValidateChildProperties = true;
                    options.LocalizationEnabled = true;
                    options.DisableDataAnnotationsValidation = true;

                    ValidatorOptions.Global.LanguageManager = new ErrorsLanguageManager();
                })
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("ru")
                };

                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }
    }
}
