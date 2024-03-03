using Luth.IntergrationPack.Interfaces;
using System.Reflection;

namespace Luth
{
    public class LexerBuilder
    {
        private Assembly _assembly = Assembly.GetExecutingAssembly();
        private TokenGenerator tokenGenerator = new TokenGenerator();
        private List<IPretokenMutation> internalPretokenMutations = new List<IPretokenMutation>();
        private AssemblyStore _assemblyFactory = new();

        public LexerBuilder ConfigureisUsingInternalNewLineMutation()
        {
            internalPretokenMutations.Add(
                new NewLineMutationStrategy()
                );

            return this;
        }

        public LexerBuilder ConfigureisUsingInternalSpaceMutation()
        {
            internalPretokenMutations.Add(
                new SpaceMutationStrategy()
                );
            return this;
        }

        public LexerBuilder ConfigureLanguage(string language)
        {
            _assembly = new AssemblyStore()[language];
            return this;
        }

        public LexerBuilder ConfigureLanguage(string language, Assembly assembly)
        {
            //var factory = new AssemblyFactory();
            _assemblyFactory[language] = assembly;
            _assembly = _assemblyFactory[language];
            return this;
        }

        public LexerBuilder ConfigureLanguages(Dictionary<string, Assembly> languages)
        {
            foreach ( var language in languages.Keys )
            {
                var assembly = languages[language];

                _assemblyFactory[language] = assembly;
                _assembly = _assemblyFactory[language];

            }
            
            return this;
        }

        public Lexer Build(string language)
        {
            _assembly = _assemblyFactory[language];

            List<IIdentifier> identifiers = _assembly
                .GetTypesWithInterfaceName(nameof(IIdentifier))
                .InstantiateAllAs<IIdentifier>();

            List<IPretokenMutation> preTokenMutations = _assembly
                .GetTypesWithInterfaceName(nameof(IPretokenMutation))
                .InstantiateAllAs<IPretokenMutation>();

            preTokenMutations.AddRange(internalPretokenMutations);

            return new Lexer(
                new TokenGenerator(identifiers.ToArray()), preTokenMutations
                );
        }
    }
}