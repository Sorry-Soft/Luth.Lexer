using Luth;
using Luth.IntergrationPack;

LexerBuilder LexerBuilder = new LexerBuilder(); 
Lexer l =LexerBuilder
    .ConfigureLanguage("PhpTopLevelLanguagePack")
    .Build();

List<Token> tokens = l.Tokenise("<?php echo(\"Hello, World!\") ;?> ").ToList();

tokens.ForEach(t => Console.WriteLine(t.Value));
