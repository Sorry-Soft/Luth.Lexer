using Luth.IntergrationPack;
using Luth.IntergrationPack.Interfaces;
using System.Drawing;
using System.Text.RegularExpressions;

namespace PhpTopLevel
{
    public class Class1 : IIdentifier
    {
        public int Orderby => 0;

        public string TokenType => "phpStart";

        public Color Color => Color.AliceBlue;

        public bool IsInError(Token? previousToken)
        {
            return false;
        }

        public bool MatchesRule(string input)
        {
             return input.StartsWith("<?php")  && input.EndsWith("?>");
        }
    }

    public class SpaceMutationStrategy : IPretokenMutation
    {
        public string OldValue => " ";

        public string NewValue => "<space>";

        public string Mutate(string input)
        {
            return input.Replace(OldValue, NewValue);
        }
    }

    public class PhpStartTagFinderStrategy : IPretokenMutation
    {
        public string OldValue => "<?";

        public string NewValue => " <?";

        public string Mutate(string input)
        {
            return input.Replace(OldValue, NewValue);
        }
    }

    public class PhpEndTagFinderStrategy : IPretokenMutation
    {
        public string OldValue => "?>";

        public string NewValue => "?> ";

        public string Mutate(string input)
        {
            return input.Replace(OldValue, NewValue);
        }
    }
}