namespace Luth.IntergrationPack.Interfaces
{
    public interface IPretokenMutation
    {
        string Mutate(string input);
        string OldValue { get; }
        string NewValue { get; }
    }
}