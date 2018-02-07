using Lionsguard.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services accessed via a key to the specified IServiceCollection instance.
        /// </summary>
        /// <typeparam name="TKey">The type of the key that identifies a service implementation.</typeparam>
        /// <typeparam name="TService">The base type or interface of the service.</typeparam>
        /// <param name="services">The IServiceCollection instance that will contain the services output from execution.</param>
        /// <param name="lifetime">The service lifetime for services created.</param>
        /// <param name="configure">An action that allows the IKeyServiceCollectionBuilder to be configured before the 
        /// services are added to the IServiceCollection instance.</param>
        /// <returns>The specified IServiceCollection instance.</returns>
        public static IServiceCollection AddKeyServices<TKey, TService>(
            this IServiceCollection services, 
            ServiceLifetime lifetime, 
            Action<IKeyServiceCollectionBuilder<TKey,TService>> configure)
            where TService : class
        {
            var builder = new KeyServiceCollectionBuilder<TKey, TService>(lifetime);
            configure?.Invoke(builder);
            builder.Build(services);
            return services;
        }

        /// <summary>
        /// Adds transient services accessed via a key to the specified IServiceCollection instance.
        /// </summary>
        /// <typeparam name="TKey">The type of the key that identifies a service implementation.</typeparam>
        /// <typeparam name="TService">The base type or interface of the service.</typeparam>
        /// <param name="services">The IServiceCollection instance that will contain the services output from execution.</param>
        /// <param name="configure">An action that allows the IKeyServiceCollectionBuilder to be configured before the 
        /// services are added to the IServiceCollection instance.</param>
        /// <returns>The specified IServiceCollection instance.</returns>
        public static IServiceCollection AddTransientKeyServices<TKey, TService>(
            this IServiceCollection services,
            Action<IKeyServiceCollectionBuilder<TKey, TService>> configure)
            where TService : class
        {
            return services.AddKeyServices(ServiceLifetime.Transient, configure);
        }

        /// <summary>
        /// Adds scoped services accessed via a key to the specified IServiceCollection instance.
        /// </summary>
        /// <typeparam name="TKey">The type of the key that identifies a service implementation.</typeparam>
        /// <typeparam name="TService">The base type or interface of the service.</typeparam>
        /// <param name="services">The IServiceCollection instance that will contain the services output from execution.</param>
        /// <param name="configure">An action that allows the IKeyServiceCollectionBuilder to be configured before the 
        /// services are added to the IServiceCollection instance.</param>
        /// <returns>The specified IServiceCollection instance.</returns>
        public static IServiceCollection AddScopedKeyServices<TKey, TService>(
            this IServiceCollection services,
            Action<IKeyServiceCollectionBuilder<TKey, TService>> configure)
            where TService : class
        {
            return services.AddKeyServices(ServiceLifetime.Scoped, configure);
        }

        /// <summary>
        /// Adds singleton services accessed via a key to the specified IServiceCollection instance.
        /// </summary>
        /// <typeparam name="TKey">The type of the key that identifies a service implementation.</typeparam>
        /// <typeparam name="TService">The base type or interface of the service.</typeparam>
        /// <param name="services">The IServiceCollection instance that will contain the services output from execution.</param>
        /// <param name="configure">An action that allows the IKeyServiceCollectionBuilder to be configured before the 
        /// services are added to the IServiceCollection instance.</param>
        /// <returns>The specified IServiceCollection instance.</returns>
        public static IServiceCollection AddSingletonKeyServices<TKey, TService>(
            this IServiceCollection services,
            Action<IKeyServiceCollectionBuilder<TKey, TService>> configure)
            where TService : class
        {
            return services.AddKeyServices(ServiceLifetime.Singleton, configure);
        }
    }
}
