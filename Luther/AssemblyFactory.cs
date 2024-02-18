using System.Reflection;

namespace Luth
{
    internal class AssemblyFactory
    {

        Dictionary<string, Assembly> _assemlblyMap = new Dictionary<string, Assembly>();
        internal AssemblyFactory()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location + "\\LanguagePacks");
            if (File.Exists(path))
            {
                foreach (string dll in Directory.GetFiles(path, "*LanguagePack*.dll"))
                {
                    Assembly assembly = Assembly.Load(dll);
                    _assemlblyMap.Add(assembly.FullName, assembly);
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