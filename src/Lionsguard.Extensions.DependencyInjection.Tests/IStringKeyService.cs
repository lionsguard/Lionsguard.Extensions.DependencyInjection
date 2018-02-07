namespace Lionsguard.Extensions.DependencyInjection.Tests
{
    public interface IStringKeyService
    {
        string GetValue();
    }

    public class StringKeyServiceA : IStringKeyService
    {
        public string GetValue() => "A";
    }

    public class StringKeyServiceB : IStringKeyService
    {
        public string GetValue() => "B";
    }

    public class StringKeyServiceC : IStringKeyService
    {
        public string GetValue() => "C";
    }
}
