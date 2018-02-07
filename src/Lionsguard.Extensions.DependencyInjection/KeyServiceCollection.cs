using System;
using System.Collections.Generic;

namespace Lionsguard.Extensions.DependencyInjection
{
    internal class KeyServiceCollection<TKey, TService> : Dictionary<TKey, Type>, IKeyServiceCollection<TKey, TService>
        where TService : class
    {
        protected IServiceProvider ServiceProvider { get; }

        public KeyServiceCollection(IServiceProvider provider)
        {
            ServiceProvider = provider;
        }

        public KeyServiceCollection(IServiceProvider provider, IDictionary<TKey, Type> services)
            : base(services)
        {
            ServiceProvider = provider;
        }

        public TService GetService(TKey key)
        {
            if (TryGetValue(key, out Type type))
            {
                return ServiceProvider.GetService(type) as TService;
            }
            return default(TService);
        }
    }
}
