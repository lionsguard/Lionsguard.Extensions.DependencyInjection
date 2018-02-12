namespace Lionsguard.Extensions.DependencyInjection.Tests
{
    public interface IStringKeyService
    {
        string GetValue();
    }

    [KeyService("A")]
    public class StringKeyServiceA : IStringKeyService
    {
        public string GetValue() => "A";
    }

    [KeyService("B")]
    public class StringKeyServiceB : IStringKeyService
    {
        public string GetValue() => "B";
    }

    [KeyService("C")]
    [KeyService("D")]
    public class StringKeyServiceC : IStringKeyService
    {
        public string GetValue() => "C";
    }
}
