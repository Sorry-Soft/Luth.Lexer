using System.Reflection;

namespace Luth
{
    internal class AssemblyStore
    {

        Dictionary<string, Assembly> _assemlblyMap = new Dictionary<string, Assembly>();
        internal AssemblyStore()
        {
            string path = Path.GetDirectoryName(Assembly.GetAssembly(typeof(AssemblyStore)).Location) + "\\LanguagePacks";
            if (Directory.Exists(path))
            {
                foreach (string dll in Directory.GetFiles(path, "*LanguagePack*.dll"))
                {
                    Assembly assembly = Assembly.LoadFile(dll);
                    _assemlblyMap.Add(assembly.GetName().Name, assembly);
                }
            }
        }

        internal void AddLanguagePack(string language, Assembly assembly)
        {

            _assemlblyMap.Add(language, assembly);
        }

        //indexer will try to resolve an external assembly. if fails. it will back out and give it's current executing assembly.
        internal Assembly this[string languagePackName]
        {
            get
            {
                if (_assemlblyMap.TryGetValue(languagePackName, out Assembly assembly))
                {
                    return assembly;
                }
                return Assembly.GetExecutingAssembly();
            }
            set
            {
                if (!_assemlblyMap.TryAdd(languagePackName, value))
                {
                    _assemlblyMap[languagePackName] = value;
                }
            }
        }
    }
}