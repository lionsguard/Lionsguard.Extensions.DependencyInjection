using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            var expected = "B";
            var actual = services.GetService<string, IStringKeyService>(expected).GetValue();
            Assert.IsTrue(actual == expected, "Expected Value = '{0}', Actual Value = '{1}'", expected, actual);
        }

        [TestMethod]
        public void ReflectionKeyServiceTest()
        {
            var services = new ServiceCollection()
                .AddKeyServicesWithReflection<string, IStringKeyService>(ServiceLifetime.Transient)
                .BuildServiceProvider();

            var service = services.GetService<string, IStringKeyService>("D"); // C and D share the same object
            var expected = "C";
            var actual = service.GetValue();
            Assert.IsTrue(actual == expected, "Expected Value = '{0}', Actual Value = '{1}'", expected, actual);
        }
    }
}
