using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Lionsguard.Extensions.DependencyInjection
{
    internal class KeyServiceCollectionBuilder<TKey, TService> : IKeyServiceCollectionBuilder<TKey, TService>
        where TService : class
    {
        protected Dictionary<TKey, Type> KeyServices { get; } = new Dictionary<TKey, Type>();
        protected ServiceLifetime Lifetime { get; }

        public KeyServiceCollectionBuilder(ServiceLifetime lifetime)
        {
            Lifetime = lifetime;
        }

        public IKeyServiceCollectionBuilder<TKey, TService> Add(TKey key, Type implementationType)
        {
            if (!typeof(TService).IsAssignableFrom(implementationType))
            {
                throw new InvalidOperationException(string.Format("The implementationType '{0}' specified does not implement the TService type '{1}'.",
                    implementationType?.FullName, typeof(TService).FullName));
            }

            KeyServices[key] = implementationType;
            return this;
        }

        public IKeyServiceCollectionBuilder<TKey, TService> Add<TImplementation>(TKey key)
            where TImplementation : class, TService
        {
            return Add(key, typeof(TImplementation));
        }

        public IServiceCollection Build(IServiceCollection services)
        {
            foreach (var kvp in KeyServices)
            {
                services.Add(new ServiceDescriptor(kvp.Value, kvp.Value, Lifetime));
            }

            services.Add(new ServiceDescriptor(typeof(KeyServiceCollection<TKey, TService>), 
                provider => new KeyServiceCollection<TKey, TService>(provider, KeyServices), Lifetime));

            return services;
        }
    }
}
