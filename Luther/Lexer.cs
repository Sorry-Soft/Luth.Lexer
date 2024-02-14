using Luth.IntergrationPack;
using Luth.IntergrationPack.Interfaces;

namespace Luth
{
    public class Lexer
    {
        private readonly TokenGenerator generator;
        private readonly List<IPretokenMutation> mutations;

        internal Lexer(TokenGenerator lexer, List<IPretokenMutation> mutations)
        {
            this.generator = lexer;
            this.mutations = mutations;
        }

        public IEnumerable<Token> Tokenise(string input)
        {
            List<Token> tokens = new List<Token>();
            foreach (IPretokenMutation mutation in mutations)
            {
                input = mutation.Mutate(input);
            }

            //i wonder if this splitting should be an internal decision 
            //possibly overidable externally....deep thoughts!   im starting to think im a strategist
            foreach (var item in input.Split(new char[] { ' ', '\n' }, StringSplitOptions.None))
            {
                string tokenValue = item;
                foreach (IPretokenMutation mutation in mutations)
                {
                    tokenValue = tokenValue.Replace(mutation.NewValue, mutation.OldValue);
                }
                tokens.Add(generator.Generate(tokenValue, tokens.Where(t => t.Type != TokenTypes.WhiteSpace).LastOrDefault()));
            }

            return tokens;
        }
    }
}