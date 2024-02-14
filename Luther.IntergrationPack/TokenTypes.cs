namespace Luth.IntergrationPack
{
    /// <summary>
    /// please feel free to name your token types however you like.<br/>
    /// these ones are just used internally.<br/>
    /// <br/>
    /// this may bite me later but for whitespace or Unknown token please use the one defined in this class.
    /// 
    /// </summary>
    public static class TokenTypes 
    {
        /// <summary>
        /// when we are refering to the previous token we ignore whitespace tokens.<br/>
        /// this might be usefull when you want to refer to make an IsInError Rule <br/>
        /// that checks if the previous token was a TypeToken.<br/><br/>
        /// knowing that the last token was whitespace doesn't normally help us.
        /// </summary>
        public static string WhiteSpace = "WhiteSpace";

        /// <summary>
        /// we are using this one internally as a default if no identifier matches a token.<br/>
        /// <br/>
        /// you can entirely ignore this one. or use your self in an identifier. <br/>
        /// it won't affect our internal process<br/><br/>you do you mate!
        /// </summary>
        public static string Unknown = "Unknown";
    }
}