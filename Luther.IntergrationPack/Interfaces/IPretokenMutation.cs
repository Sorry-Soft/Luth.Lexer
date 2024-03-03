namespace Luth.IntergrationPack.Interfaces
{
    public interface IPretokenMutation
    {
        string Mutate(string input);
        string Revert(string input);
        int GetOrderBy();
        string OldValue { get; }
        string NewValue { get; }
    }
}