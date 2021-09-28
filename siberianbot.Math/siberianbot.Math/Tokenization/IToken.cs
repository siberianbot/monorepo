namespace siberianbot.Math.Tokenization
{
    public interface IToken
    {
        public string Value { get; }
        
        public IToken Next { get; }
        
        public TokenType Type { get; }
    }
}