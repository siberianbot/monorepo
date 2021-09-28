namespace siberianbot.Tokenization.Types
{
    /// <summary>
    ///     An interface of token.
    /// </summary>
    public interface IToken
    {
        /// <summary>
        ///     Token value.
        /// </summary>
        string Value { get; }

        /// <summary>
        ///     Next token.
        /// </summary>
        IToken Next { get; set; }
    }
}