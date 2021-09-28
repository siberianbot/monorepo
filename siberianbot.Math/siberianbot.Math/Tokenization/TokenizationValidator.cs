using System;
using System.Globalization;
using siberianbot.Math.Helpers;

namespace siberianbot.Math.Tokenization
{
    /// <summary>
    ///     Validates result of tokenization.
    /// </summary>
    public sealed class TokenizationValidator
    {
        static TokenizationValidator()
        {
            Default = new TokenizationValidator();
        }

        public static TokenizationValidator Default { get; }

        public void Validate(IToken token)
        {
            // TODO: texts - what should I validate?
            // TODO: brackets and operators are correctly defined by Tokenizer, but validation is required. Why?

            IToken current = token;
            while (current != null)
            {
                if (token.Type == TokenType.Number &&
                    !decimal.TryParse(token.Value, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal _))
                {
                    throw new ArgumentException($"token {token.Value} is invalid number");
                }

                if (token.Type.IsNotIn(TokenType.Bracket, TokenType.Text, TokenType.Operator))
                {
                    throw new ArgumentOutOfRangeException(nameof(token.Next), $"token {token.Value} have incompatible type {token.Type}");
                }

                current = current.Next;
            }
        }
    }
}