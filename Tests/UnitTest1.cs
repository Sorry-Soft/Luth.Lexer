using Luth;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;

namespace Tests
{
    public class LexerBuilderTests
    {

        [Test]
        public void Build_DoesNotThrowError_Given_ConfigureLanguage_IsProvidedValidAssembly()
        {
            Assert.DoesNotThrow(() =>
            {
                LexerBuilder LexerBuilder = new LexerBuilder();
                Lexer l = LexerBuilder
                    .ConfigureLanguage("PhpTopLevelLanguagePack", Assembly.GetAssembly(typeof(TestPhpLanguagePack.PhpBlockIdentifier))!)
                    .Build();
            });
        }

        [Test]
        public void Build_DoesNotThrowError_Given_ConfigureLanguage_IsProvidedNameOfLanguagePackInLanguagePackFolder()
        {
            Assert.DoesNotThrow(() =>
            {
                LexerBuilder LexerBuilder = new LexerBuilder();
                Lexer l = LexerBuilder
                    .ConfigureLanguage("TestPhpLanguagePack")
                    .Build();
            });
        }

        [Test]
        public void Build_DoesNotThrowError_Given_ConfigureLanguage_IsProvidedNameAndValidAssemblyInLanguagePackFolder()
        {
            Assert.DoesNotThrow(() =>
            {
                Dictionary<string, Assembly> assemblies = new Dictionary<string, Assembly>()
                {
                    { "PhpTopLevelLanguagePack", Assembly.GetAssembly(typeof(TestPhpLanguagePack.PhpBlockIdentifier))! }
                };
                LexerBuilder LexerBuilder = new LexerBuilder();
                Lexer l = LexerBuilder
                    .ConfigureLanguages(assemblies)
                    .Build("PhpTopLevelLanguagePack");
            });
        }
    }
}