using Luth.IntergrationPack.Interfaces;

namespace Luth
{
    public class SpaceMutationStrategy : IPretokenMutation
    {
        public string OldValue => " ";

        public string NewValue => " <space> ";

        public string Mutate(string input) => input.Replace(OldValue, NewValue);
        public string Revert(string input) => input.Replace(NewValue, OldValue);

        public int GetOrderBy() => 1;
    }
}