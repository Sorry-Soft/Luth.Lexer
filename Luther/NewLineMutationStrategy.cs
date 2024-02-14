using Luth.IntergrationPack.Interfaces;

namespace Luth
{
    public class NewLineMutationStrategy : IPretokenMutation
    {
        public string OldValue => "\n";

        public string NewValue => " <newLine>\n";

        public string Mutate(string input)
        {
            return input.Replace(OldValue, NewValue);
        }
    }
}