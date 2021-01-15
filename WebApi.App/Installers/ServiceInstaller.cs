using Global.Library.Common.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Library.Services;

namespace WebApi.App.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(
              IServiceCollection serviceCollection
            , IConfiguration configuration)
        {
            serviceCollection.AddTransient<IUsersService, UsersService>();
        }
    }
}