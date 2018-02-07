using System;
using System.Collections.Generic;

namespace Lionsguard.Extensions.DependencyInjection
{
    /// <summary>
    /// Represents a collection of key/implementationType pairs.
    /// </summary>
    /// <typeparam name="TKey">The key used to locate the implementation type.</typeparam>
    /// <typeparam name="TService">The service type that values stored in the dictionary must implement.</typeparam>
    public interface IKeyServiceCollection<TKey, TService> : IDictionary<TKey, Type>
        where TService : class
    {
        /// <summary>
        /// Gets an instance of the implementation type associated with the specified key.
        /// </summary>
        /// <param name="key">The key indicating the service implementation to return.</param>
        /// <returns>An instance of TService.</returns>
        TService GetService(TKey key);
    }
}
