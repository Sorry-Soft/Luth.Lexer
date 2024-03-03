using Luth.IntergrationPack;
using Luth.IntergrationPack.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace Luth
{
    public class Lexer
    {
        private readonly TokenGenerator generator;
        private readonly IOrderedEnumerable<IPretokenMutation> mutations;

        internal Lexer(TokenGenerator lexer, List<IPretokenMutation> mutations)
        {
            this.generator = lexer;
            this.mutations = mutations.OrderBy(x => x.GetOrderBy());
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
            //foreach (var item in input.Split(new char[] { ' ', '\n' }, StringSplitOptions.None))
            //{
            //    string tokenValue = item;
            //    foreach (IPretokenMutation mutation in mutations.OrderBy(x => x.GetOrderBy()) )
            //    {
            //        tokenValue = tokenValue.Replace(mutation.NewValue, mutation.OldValue);
            //    }
            //    tokens.Add(generator.Generate(tokenValue, tokens.Where(t => t.Type != TokenTypes.WhiteSpace).LastOrDefault()));
            //}

            var inputs = input.Split(new char[] { ' ', '\n' }, StringSplitOptions.None);
            for (int i = 0; i < inputs.Count(); i++)
            {
                var currentItem = inputs[i];

                // Calculate previous item
                var prevItem = (i > 0) ? inputs[i - 1] : "";
                var prevToken = tokens.Where(t => t.Type != TokenTypes.WhiteSpace).LastOrDefault();

                // Calculate next item
                var nextItem = (i < inputs.Count() - 1) ? inputs[i + 1] : "";
                var nextToken = generator.Generate(nextItem, null);

                foreach (IPretokenMutation mutation in mutations.OrderBy(x => x.GetOrderBy()))
                {
                    try
                    {
                        currentItem = mutation.Revert(currentItem);
                    }
                    catch { }
                }
                tokens.Add(generator.Generate(currentItem, prevToken, nextToken));
            }

            return tokens;
        }
    }
}