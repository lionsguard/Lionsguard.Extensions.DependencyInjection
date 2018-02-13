using Lionsguard.Extensions.DependencyInjection.TestLib;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lionsguard.Extensions.DependencyInjection.Tests
{
    [TestClass]
    public class KeyServiceCollectionTests
    {
        [TestMethod]
        public void StringKeyTest()
        {
            var services = new ServiceCollection()
                .AddTransientKeyServices<string, IStringKeyService>(builder =>
                {
                    builder.Add<StringKeyServiceA>("A");
                    builder.Add<StringKeyServiceB>("B");
                    builder.Add<StringKeyServiceC>("C");
                })
                .BuildServiceProvider();

            ValidateService<string, IStringKeyService, string>(services, "B", "B", s => s.GetValue());
        }

        [TestMethod]
        public void ReflectionKeyServiceTest()
        {
            var services = new ServiceCollection()
                .AddKeyServicesWithReflection<string, IStringKeyService>(ServiceLifetime.Transient)
                .BuildServiceProvider();

            ValidateService<string, IStringKeyService, string>(services, "D", "C", s => s.GetValue());
        }

        [TestMethod]
        public void ExternalLibraryReflectionTest()
        {
            var services = new ServiceCollection()
                .AddOtherServices()
                .AddKeyServicesWithReflection<string, IStringKeyService>(ServiceLifetime.Transient)
                .BuildServiceProvider();

            ValidateService<string, IStringKeyService, string>(services, "D", "C", s => s.GetValue());
            ValidateService<string, IOtherStringKeyService, string>(services, "2", "2", s => s.GetValue());
        }

        [TestMethod]
        public void MixedExternalLibraryReflectionTest()
        {
            var services = new ServiceCollection()
                .AddOtherServices()
                .AddKeyServicesWithReflection<int, IIntKeyService>(ServiceLifetime.Transient)
                .BuildServiceProvider();

            ValidateService<int, IIntKeyService, int>(services, 1, 1, s => s.GetValue()); // one from ref assembly
            ValidateService<int, IIntKeyService, int>(services, 4, 4, s => s.GetValue()); // one from current assembly
        }

        void ValidateService<TKey, TService, TValue>(IServiceProvider services, TKey key, TValue expectedValue, Func<TService,TValue> valueAccessor)
            where TService : class
        {
            var service = services.GetService<TKey, TService>(key);
            Assert.IsNotNull(service, "Service '{0}' was not found.", typeof(TService));

            var actual = valueAccessor.Invoke(service);
            Assert.AreEqual(actual, expectedValue, "Expected = '{0}', Actual = '{1}'", expectedValue, actual);
        }
    }
}
