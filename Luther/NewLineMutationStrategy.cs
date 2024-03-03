using Luth.IntergrationPack.Interfaces;

namespace Luth
{
    public class NewLineMutationStrategy : IPretokenMutation
    {
        public string Mutate(string input) => input.Replace(OldValue, NewValue);
        public string Revert(string input) => input.Replace(NewValue, OldValue);

        public int GetOrderBy() => 1;

        public string OldValue => "\n";

        public string NewValue => " <newLine>\n";
    }
}