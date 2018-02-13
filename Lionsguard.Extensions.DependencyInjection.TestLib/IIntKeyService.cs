namespace Lionsguard.Extensions.DependencyInjection.TestLib
{
    public interface IIntKeyService
    {
        int GetValue();
    }

    [KeyService(1)]
    public class IntKeyService1 : IIntKeyService
    {
        public int GetValue()
        {
            return 1;
        }
    }

    [KeyService(2)]
    public class IntKeyService2 : IIntKeyService
    {
        public int GetValue()
        {
            return 2;
        }
    }

    [KeyService(3)]
    public class IntKeyService3 : IIntKeyService
    {
        public int GetValue()
        {
            return 3;
        }
    }
}
