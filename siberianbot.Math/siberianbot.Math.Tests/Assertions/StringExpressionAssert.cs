using siberianbot.Math.Tests.Models;
using siberianbot.Math.Tokenization;
using Xunit;

namespace siberianbot.Math.Tests.Assertions
{
    public static class StringExpressionAssert
    {
        public static void TokenizationIsValid(StringExpression expression, IToken rootToken)
        {
            if (expression.Tokens.Length == 0)
            {
                Assert.Null(rootToken);
            }
            
            IToken currentToken = rootToken;
            foreach (string token in expression.Tokens)
            {
                Assert.Equal(token, currentToken.Value);

                currentToken = currentToken.Next;
            }
        }
    }
}