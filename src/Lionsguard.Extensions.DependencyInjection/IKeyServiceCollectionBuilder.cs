using Microsoft.Extensions.DependencyInjection;
using System;

namespace Lionsguard.Extensions.DependencyInjection
{
    /// <summary>
    /// Represents a class used to build key/services.
    /// </summary>
    /// <typeparam name="TKey">The type of the key to be used.</typeparam>
    /// <typeparam name="TService">The type of the service that implementation types must implement.</typeparam>
    public interface IKeyServiceCollectionBuilder<TKey, TService>
        where TService : class
    {
        /// <summary>
        /// Adds the specified implementation type for the specified key.
        /// </summary>
        /// <param name="key">The key for this implementation type.</param>
        /// <param name="implementationType">The System.Type of the implementation of TService.</param>
        /// <returns>The current builder instance.</returns>
        IKeyServiceCollectionBuilder<TKey, TService> Add(TKey key, Type implementationType);

        /// <summary>
        /// Adds the specified implementation type for the specified key.
        /// </summary>
        /// <typeparam name="TImplementation">The generic type for the implementation type.</typeparam>
        /// <param name="key">The key for this implementation type.</param>
        /// <returns>The current builder instance.</returns>
        IKeyServiceCollectionBuilder<TKey, TService> Add<TImplementation>(TKey key)
            where TImplementation : class, TService;

        /// <summary>
        /// Builds the services for the current builder collection.
        /// </summary>
        /// <param name="services">The IServiceCollection instances in which to add services.</param>
        /// <returns>The specified IServiceCollection instance.</returns>
        IServiceCollection Build(IServiceCollection services);
    }
}
