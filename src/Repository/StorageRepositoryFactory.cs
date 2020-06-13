// ==================================================
// Storage Repository Factory Implementation
// ==================================================

using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using CloudAgnosticStorageAPI.Interface;

namespace CloudAgnosticStorageAPI.Repository
{
    public class StorageRepositoryFactory : IStorageRepositoryFactory
    {
        IServiceProvider _provider;
        public StorageRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IStorageRepository GetStorgeRepository(string repository)
        {
            var services = _provider.GetServices<IStorageRepository>().ToList();
            if (services.Count == 1)
            {
                return services.First<IStorageRepository>();
            }
            else
            {
                return services.Find(p => p.GetType().ToString().ToLower().Contains(repository.ToLower()));
            }
        }
    }
}
