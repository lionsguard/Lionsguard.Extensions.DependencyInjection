using Lionsguard.Extensions.DependencyInjection.TestLib;

namespace Lionsguard.Extensions.DependencyInjection.Tests
{
    [KeyService(4)]
    public class IntKeyService4 : IIntKeyService
    {
        public int GetValue()
        {
            return 4;
        }
    }

    [KeyService(5)]
    public class IntKeyService5 : IIntKeyService
    {
        public int GetValue()
        {
            return 5;
        }
    }
}
