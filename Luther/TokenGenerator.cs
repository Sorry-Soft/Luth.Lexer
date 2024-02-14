﻿using Luth.IntergrationPack;
using Luth.IntergrationPack.Interfaces;
using System.Drawing;

namespace Luth
{
    internal class TokenGenerator
    {
        private readonly IIdentifier[] identifiers;

        internal TokenGenerator(params IIdentifier[] identifiers)
        {
            this.identifiers = identifiers;
        }

        internal Token Generate(string input, Token? previousToken) 
        {
            foreach (IIdentifier identifier in identifiers.OrderBy(i=>i.Orderby))
            {
                if (identifier.MatchesRule(input))
                {
                    Token token = new Token()
                    {
                        Type = identifier.TokenType,
                        Value = input,
                        Color = identifier.Color,
                        InError = identifier.IsInError(previousToken)
                    };

                    //i know! i know this is not a good idea. but ive only gone and done it anyway.
                    if (previousToken.Type == TokenTypes.WhiteSpace)
                    {
                        previousToken = token;
                    }
                    return token;
                }
            }

            //default to unknown Token.
            return new Token()
            {
                Type = TokenTypes.Unknown,
                Color = Color.White
            };
        }
    }
}