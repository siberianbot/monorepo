using System;
using System.Collections.Generic;
using siberianbot.Math.Helpers;

namespace siberianbot.Math.Tokenization
{
    /// <summary>
    ///     Parses any mathematical expression and returns bunch of tokens.
    /// </summary>
    public sealed class Tokenizer
    {
        static Tokenizer()
        {
            Default = new Tokenizer();
        }

        public static Tokenizer Default { get; }

        public IToken Parse(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                return null;
            }

            List<Token> tokens = new();

            string value = string.Empty;
            TokenType type = TokenType.None;

            for (int pos = 0; pos < expression.Length; pos++)
            {
                char ch = expression[pos];

                if (char.IsWhiteSpace(ch))
                {
                    continue;
                }

                if (IsBracket(ch))
                {
                    if (value.Length > 0)
                    {
                        tokens.Add(new Token(value, type));
                        value = string.Empty;
                    }

                    tokens.Add(new Token(ch, TokenType.Bracket));
                    continue;
                }

                if (IsOperator(ch))
                {
                    if (value.Length > 0)
                    {
                        tokens.Add(new Token(value, type));
                        value = string.Empty;
                    }

                    tokens.Add(new Token(ch, TokenType.Operator));
                    continue;
                }

                if (IsNumber(ch))
                {
                    if (value.Length > 0 && type != TokenType.Number)
                    {
                        tokens.Add(new Token(value, type));
                        value = string.Empty;
                    }

                    type = TokenType.Number;
                    value += ch;
                    continue;
                }

                if (IsText(ch))
                {
                    if (value.Length > 0 && type != TokenType.Text)
                    {
                        tokens.Add(new Token(value, type));
                        value = string.Empty;
                    }

                    type = TokenType.Text;
                    value += ch;
                    continue;
                }

                throw new InvalidOperationException($"Unexpected character '{ch}' at position {pos}");
            }

            if (value.Length > 0)
            {
                tokens.Add(new Token(value, type));
            }

            if (tokens.Count == 0)
            {
                return null;
            }

            Token rootToken = tokens[0];
            Token currentToken = rootToken;

            int i = 1;
            while (i < tokens.Count)
            {
                currentToken.Next = tokens[i];
                currentToken = tokens[i];

                i++;
            }

            return rootToken;
        }

        private bool IsBracket(char ch)
        {
            return ch.IsIn('(', ')');
        }

        private bool IsNumber(char ch)
        {
            return char.IsDigit(ch) || ch.IsIn(',', '.');
        }

        private bool IsText(char ch)
        {
            return char.IsLetter(ch);
        }

        private bool IsOperator(char ch)
        {
            return ch.IsIn('+', '-', '*', '/', '^');
        }
    }
}