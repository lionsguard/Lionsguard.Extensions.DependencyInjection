namespace Lionsguard.Extensions.DependencyInjection.TestLib
{
    public interface IOtherStringKeyService
    {
        string GetValue();
    }

    [KeyService("1")]
    public class OtherStringKeyService1 : IOtherStringKeyService
    {
        public string GetValue()
        {
            return "1";
        }
    }

    [KeyService("2")]
    public class OtherStringKeyService2 : IOtherStringKeyService
    {
        public string GetValue()
        {
            return "2";
        }
    }
}
