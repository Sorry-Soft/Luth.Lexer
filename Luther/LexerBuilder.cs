using Luth.IntergrationPack.Interfaces;
using System.Reflection;

namespace Luth
{
    public class LexerBuilder
    {
        private Assembly _assembly = Assembly.GetExecutingAssembly();
        private TokenGenerator tokenGenerator = new TokenGenerator();
        private List<IPretokenMutation> internalPretokenMutations = new List<IPretokenMutation>();

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
            _assembly = new AssemblyFactory()[language];
            return this;
        }

        public Lexer Build()
        {
            List<IIdentifier> identifiers = _assembly
                .GetTypesWithInterfaceName("IIdentifier")
                .InstantiateAllAs<IIdentifier>();

            List<IPretokenMutation> preTokenMutations = _assembly
                .GetTypesWithInterfaceName("IPreTokenMutation")
                .InstantiateAllAs<IPretokenMutation>();

            preTokenMutations.AddRange(internalPretokenMutations);

            return new Lexer(
                new TokenGenerator(identifiers.ToArray()), preTokenMutations
                );
        }
    }
}