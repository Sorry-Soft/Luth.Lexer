using Luth.IntergrationPack.Interfaces;

namespace Luth
{
    public class SpaceMutationStrategy : IPretokenMutation
    {
        public string OldValue => " ";

        public string NewValue => " <space> ";

        public string Mutate(string input)
        {
            return input.Replace(OldValue, NewValue);
        }
    }
}