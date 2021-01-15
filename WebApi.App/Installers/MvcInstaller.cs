using Global.Library.Common.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;

namespace WebApi.App.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(
              IServiceCollection serviceCollection
            , IConfiguration configuration)
        {
            serviceCollection.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
            });

            serviceCollection.AddControllers()
                .AddNewtonsoftJson(c =>
                {
                    c.SerializerSettings.Converters.Add(new StringEnumConverter());
                    c.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });
        }
    }
}