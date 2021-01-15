using Global.Library.Common.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Library.Repositories;

namespace WebApi.App.Installers
{
    public class RepositoryInstaller : IInstaller
    {
        public void InstallServices(
              IServiceCollection serviceCollection
            , IConfiguration configuration)
        {
            serviceCollection.AddTransient<IUsersRepository, UsersRepository>();
        }
    }
}