namespace siberianbot.Math.Tests.Models
{
    public class StringExpression
    {
        public StringExpression(params string[] tokens)
        {
            Tokens = tokens;
        }

        public string Expression
        {
            get => string.Concat(Tokens);
        }

        public string[] Tokens { get; }

        public override string ToString()
        {
            return Tokens.Length > 0 ? Expression : "<empty expression>";
        }
    }
}