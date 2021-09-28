using System;
using siberianbot.Math.Tests.Assertions;
using siberianbot.Math.Tests.DataSources;
using siberianbot.Math.Tests.Models;
using siberianbot.Math.Tokenization;
using Xunit;
using Xunit.Abstractions;

namespace siberianbot.Math.Tests
{
    public class TokenizerTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TokenizerTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [ClassData(typeof(StringExpressionDataSource))]
        public void Successful(StringExpression expression)
        {
            _testOutputHelper.WriteLine($"source expression: {expression.Expression}");

            IToken token = Tokenizer.Default.Parse(expression.Expression);

            _testOutputHelper.WriteLine($"parsed expression: {token}");
            StringExpressionAssert.TokenizationIsValid(expression, token);
        }

        [Theory]
        [ClassData(typeof(InvalidCharactersDataSource))]
        public void Failed_UnexpectedCharacter(char ch)
        {
            _testOutputHelper.WriteLine($"invalid character: {ch}");

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => Tokenizer.Default.Parse(ch.ToString()));

            _testOutputHelper.WriteLine($"exception: {exception.Message}");
        }
    }
}