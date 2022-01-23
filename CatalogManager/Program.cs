using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace CatalogsManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(AddAppConfiguration)
                .ConfigureLogging(ConfigureLogging)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void ConfigureLogging(HostBuilderContext builderContext, ILoggingBuilder loggingBuilder)
        {
            loggingBuilder.AddSeq(builderContext.Configuration.GetSection("Logging:Seq"));
        }

        private static void AddAppConfiguration(HostBuilderContext builderContext, IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Sources.Clear();

            configurationBuilder.AddJsonFile("appsettings.json");
            configurationBuilder.AddJsonFile($"appsettings.{builderContext.HostingEnvironment.EnvironmentName}.json", optional: true);
            configurationBuilder.AddEnvironmentVariables();

            if (builderContext.HostingEnvironment.IsDevelopment())
            {
                configurationBuilder.AddUserSecrets<Startup>();
            }
            else if(builderContext.HostingEnvironment.IsProduction())
            {
                var root = configurationBuilder.Build();

                var url = root["KeyVault:Vault"];
                var clientId = root["KeyVault:ClientId"];
                var tenantId = root["KeyVault:TenantId"];
                var clientSecret = root["KeyVault:SecretKey"];

                var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
                var client = new SecretClient(new Uri(url), credential);

                configurationBuilder.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());
            }
        }
    }
}
