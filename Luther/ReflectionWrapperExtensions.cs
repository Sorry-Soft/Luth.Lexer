using System.Reflection;

namespace Luth
{
    internal static class ReflectionWrapperExtensions 
    {
        internal static List<Type> GetTypesWithInterfaceName(this Assembly assembly, string interfaceName) 
        { 
            return assembly.GetTypes().Where(t => t.GetInterface(interfaceName) is not null).ToList();
        }

        internal static List<TInterface> InstantiateAllAs<TInterface>(this List<Type> types)
        {
            List<TInterface> desiredTypes = new List<TInterface>();
            foreach (Type type in types) 
            {
                TInterface? desideredType = (TInterface?)Activator.CreateInstance(type, false);
                if (desideredType is not null) desiredTypes.Add(desideredType);
            }

            return desiredTypes;
        }
    }
}