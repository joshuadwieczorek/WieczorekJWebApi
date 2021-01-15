using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Global.Library.Common.Contracts
{
    public interface IInstaller
    {
        public void InstallServices(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}