using Bugsnag.AspNet.Core;
using Global.Library.Common.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.App.Installers
{
    public class BugSnagInstaller : IInstaller
    {
        public void InstallServices(
              IServiceCollection serviceCollection
            , IConfiguration configuration)
        {
            serviceCollection.AddBugsnag(cfg => {
                cfg.ApiKey = configuration["BugsnagApiKey"];
                cfg.AppType = configuration["AppType"];
                cfg.AppVersion = configuration["AppReleaseVersion"];
                cfg.ReleaseStage = configuration["AppReleaseStage"];
            });
        }
    }
}
