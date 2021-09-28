namespace siberianbot.Algorithms.Tokenization
{
    public sealed class Token
    {
        public string Value { get; internal set; }

        public Token Next { get; internal set; }
    }
}