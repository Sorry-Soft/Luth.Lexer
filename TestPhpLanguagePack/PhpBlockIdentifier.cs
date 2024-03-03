using Luth.IntergrationPack;
using Luth.IntergrationPack.Interfaces;
using System.Drawing;

namespace TestPhpLanguagePack
{
    public class PhpBlockIdentifier : IIdentifier
    {
        public int Orderby => 0;

        public string TokenType => "phpStart";

        public Color Color => Color.AliceBlue;

        public bool IsInError(Token? previousToken)
        {
            return false;
        }

        public bool IsInError(Token? previousToken, Token? nextToken)
        {
            return false;
        }

        public bool MatchesRule(string input)
        {
            return input.StartsWith("<?") && input.EndsWith("?>");
        }
    }

    public class SpaceMutationStrategy : IPretokenMutation
    {
        public string OldValue => " ";

        public string NewValue => "<space>";

        public int GetOrderBy()
        {
            return 0;
        }

        public string Mutate(string input)
        {
            return input.Replace(OldValue, NewValue);
        }

        public string Revert(string input)
        {
            throw new NotImplementedException();
        }
    }

    public class PhpStartTagFinderStrategy : IPretokenMutation
    {
        public string OldValue => "<?";

        public string NewValue => " <?";

        public int GetOrderBy()
        {
            return 1;
        }

        public string Mutate(string input)
        {
            return input.Replace(OldValue, NewValue);
        }

        public string Revert(string input)
        {
            return input.Replace(NewValue, OldValue);
        }
    }

    public class PhpEndTagFinderStrategy : IPretokenMutation
    {
        public string OldValue => "?>";

        public string NewValue => "?> ";

        public int GetOrderBy()
        {
            return 2;
        }

        public string Mutate(string input)
        {
            return input.Replace(OldValue, NewValue);
        }

        public string Revert(string input)
        {
            return input.Replace(NewValue, OldValue);
        }
    }
}