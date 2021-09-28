namespace siberianbot.Tokenization.Types.InferenceRules
{
    /// <summary>
    ///     An interface of tokenization inference rule.
    ///     Inference rule defines token.
    /// </summary>
    public interface IInferenceRule
    {
        /// <summary>
        ///     Checks that character 'ch' matches this inference rule.
        /// </summary>
        /// <param name="ch">Character.</param>
        /// <returns>Character matches this inference rule.</returns>
        bool Matches(char ch);

        /// <summary>
        ///     Tokenizes string which is matches this inference rule..
        /// </summary>
        /// <param name="str">String value for using in token.</param>
        /// <returns>Token.</returns>
        IToken Tokenize(string str);
    }
}