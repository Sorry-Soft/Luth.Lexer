using Luth.IntergrationPack;
using System.Drawing;

namespace Luth.IntergrationPack.Interfaces
{
    /// <summary>
    /// Please apply me to a class you intend for our <br/>
    /// library to identify patterns in plain text.<br/> 
    /// <br/> 
    /// We will use this to convert your plain text input into tokens via the lexer
    /// <br/>
    /// example :: <br/>
    /// public class KeyWordIdentifier : IIdentifier<br/> 
    /// {<br/> 
    /// <br/> 
    /// private string[] keywords = new string[] <br/>
    /// {<br/>
    ///       "new", "using", "unsafe"<br/> 
    /// };<br/>
    /// <br/>
    /// public int Orderby => 0;<br/>
    /// <br/>
    /// public string TokenType => "KeyWord";<br/>
    /// <br/>
    /// public Color Color => Color.Red;<br/>
    /// <br/>
    /// public bool MatchesRule(string input)<br/>
    /// {<br/>
    /// return keywords.Contains(input);<br/>                        
    /// }<br/>
    /// <br/>
    /// public bool IsInError(Token? previousToken)<br/>
    /// {<br/>
    /// if (previousToken.Type == this.TokenType) return true;<br/>
    /// return false;<br/>                          
    /// }<br/>
    /// }
    /// </summary>
    public interface IIdentifier
    {
        int Orderby { get; }
        bool MatchesRule(string input);
        public bool IsInError(Token? previousToken, Token? nextToken);
        string TokenType { get; }
        Color Color { get; }
    }
}