using System;

namespace Lionsguard.Extensions.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class KeyServiceAttribute : Attribute
    {
        public object Key { get; }

        public KeyServiceAttribute(object key)
        {
            Key = key;
        }
    }
}
