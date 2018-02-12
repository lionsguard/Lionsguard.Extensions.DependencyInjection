using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lionsguard.Extensions.DependencyInjection
{
    public static class TypeHelper
    {
        /// <summary>
        /// Gets all of the types for the current AppDomain of the specified Type and with the specified Attribute.
        /// </summary>
        /// <typeparam name="TType">The type of objects to find.</typeparam>
        /// <typeparam name="TAttribute">The System.Attribute the selected types must contain.</typeparam>
        /// <param name="isAbstract">Whether or not the type is abstract.</param>
        /// <param name="isInterface">Whether or not the type is an interface.</param>
        /// <returns>A enumerable list of System.Types of the specified type and containing the specified System.Attribute</returns>
        public static IEnumerable<Type> GetTypesWithCustomAttributes<TType, TAttribute>(bool isAbstract = false, bool isInterface = false)
            where TAttribute : Attribute
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = new List<Type>();
            foreach (var assembly in assemblies)
            {
                types.AddRange(assembly.GetTypes()
                    .Where(t => t.IsAbstract == isAbstract
                        && t.IsInterface == isInterface
                        && (t.GetTypeInfo().IsSubclassOf(typeof(TType)) || typeof(TType).GetTypeInfo().IsAssignableFrom(t))
                        && t.GetTypeInfo().GetCustomAttributes<TAttribute>().Any()
                        ));
            }
            return types;
        }
    }
}
