namespace siberianbot.Math.Tokenization
{
    internal sealed class Token : IToken
    {
        public Token(char value, TokenType type)
        {
            Value = value.ToString();
            Type = type;
        }

        public Token(string value, TokenType type)
        {
            Value = value;
            Type = type;
        }

        public string Value { get; }

        public TokenType Type { get; }

        public IToken Next { get; set; }

        public override string ToString()
        {
            return Next != null ? $"{Value} -> {Next}" : Value;
        }
    }
}