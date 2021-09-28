using System;
using System.IO;
using siberianbot.Tokenization.Types;
using siberianbot.Tokenization.Types.InferenceRules;
using siberianbot.Tokenization.Utils;

namespace siberianbot.Tokenization
{
    /// <summary>
    ///     Performs tokenization.
    /// </summary>
    public sealed class Tokenizer
    {
        /// <summary>
        ///     Creates instance of tokenizer.
        /// </summary>
        public Tokenizer() : this(null)
        {
            //
        }

        /// <summary>
        ///     Creates instance of tokenizer.
        /// </summary>
        /// <param name="options">Tokenizer options. If null - options from <see cref="TokenizerOptions.Default" /> are used.</param>
        public Tokenizer(TokenizerOptions options)
        {
            Options = options ?? TokenizerOptions.Default;
        }

        /// <summary>
        ///     Current instance of tokenizer options.
        /// </summary>
        public TokenizerOptions Options { get; }

        /// <summary>
        ///     Parses string and returns first token.
        /// </summary>
        /// <param name="str">String for parsing.</param>
        /// <returns>First token of parsed string or null if no tokens.</returns>
        /// <exception cref="ArgumentNullException">Input string is null.</exception>
        public IToken Parse(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (str.Length == 0 ||
                !Options.IncludeWhitespaces && string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            using StringReader reader = new(str);

            return Parse(reader);
        }

        /// <summary>
        ///     Parses data from <see cref="TextReader" /> and returns first token.
        /// </summary>
        /// <param name="reader"><see cref="TextReader" /> which contains data for parsing.</param>
        /// <returns>First token of parsed data from <see cref="TextReader" />.</returns>
        public IToken Parse(TextReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            using CountingTextReader countingReader = new(reader);

            IToken rootToken = null;
            IToken currentToken = null;
            IInferenceRule currentRule = null;
            string tokenValue = string.Empty;

            int intCh = -1;
            while ((intCh = countingReader.Read()) != -1)
            {
                char ch = (char) intCh;

                if (char.IsWhiteSpace(ch) && !Options.IncludeWhitespaces)
                {
                    continue;
                }

                bool ruleMatched = false;

                foreach (IInferenceRule rule in Options.InferenceRules)
                {
                    if (!rule.Matches(ch))
                    {
                        continue;
                    }

                    if (rule != currentRule)
                    {
                        if (rootToken == null)
                        {
                            currentToken = currentRule?.Tokenize(tokenValue);
                            rootToken = currentToken;
                        }
                        else
                        {
                            currentToken.Next = currentRule?.Tokenize(tokenValue);
                        }

                        tokenValue = string.Empty;
                        currentRule = rule;
                    }

                    tokenValue += ch;
                    ruleMatched = true;

                    break;
                }

                if (ruleMatched)
                {
                    continue;
                }

                throw new InvalidOperationException($"No inference rule matched for character '{ch}' at {countingReader.CurrentLine}:{countingReader.CurrentPosition}.");
            }

            return rootToken;
        }
    }
}