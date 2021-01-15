using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Global.Library.Common.Contracts;

namespace Global.Library.ExtensionMethods
{
    public static class ServicesInstaller
    {
        public static void InstallServicesFromAssembly<T>(
              this IServiceCollection services
            , IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentException(nameof(services));

            List<IInstaller> installers = typeof(T).Assembly.ExportedTypes.Where(t => typeof(IInstaller).IsAssignableFrom(t)
                                                            && !t.IsInterface
                                                            && !t.IsAbstract)
                                                            .Select(Activator.CreateInstance)
                                                            .Cast<IInstaller>()
                                                            .ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}