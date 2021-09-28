using System.Collections.Generic;
using siberianbot.Tokenization.Types.InferenceRules;

namespace siberianbot.Tokenization
{
    /// <summary>
    ///     Options for <see cref="Tokenizer" />.
    /// </summary>
    public sealed class TokenizerOptions
    {
        /// <summary>
        ///     Instance of options with default values.
        /// </summary>
        public static TokenizerOptions Default
        {
            get => new()
            {
                IncludeWhitespaces = false
            };
        }

        /// <summary>
        ///     Include whitespace characters in tokenization. Default: false.
        /// </summary>
        public bool IncludeWhitespaces { get; set; }

        /// <summary>
        ///     Collection of inference rules which are used for tokenization. There's no rules by default.
        /// </summary>
        public ICollection<IInferenceRule> InferenceRules { get; set; } = new List<IInferenceRule>();
    }
}