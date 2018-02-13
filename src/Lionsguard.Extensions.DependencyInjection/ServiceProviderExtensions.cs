using Lionsguard.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Gets an implementation of TService for the specified key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key that identifies a service implementation.</typeparam>
        /// <typeparam name="TService">The base type or interface of the service.</typeparam>
        /// <param name="services">The current IServiceProvider instance.</param>
        /// <param name="key">The key of the service implementation to return.</param>
        /// <returns>An implementation of TService for the specified key.</returns>
        public static TService GetService<TKey, TService>(this IServiceProvider services, TKey key)
            where TService : class
        {
            var collections = services.GetServices<KeyServiceCollection<TKey, TService>>();
            var collection = collections?.FirstOrDefault(o => o.ContainsKey(key));
            return collection?.GetService(key);
        }
    }
}
