using Lionsguard.Extensions.DependencyInjection.TestLib;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddOtherServices(this IServiceCollection services)
        {
            services.AddKeyServices<string, IOtherStringKeyService>(ServiceLifetime.Transient, ksb =>
            {
                ksb.Add<OtherStringKeyService1>("1");
                ksb.Add<OtherStringKeyService2>("2");
            });
            return services;
        }
    }
}
