using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using siberianbot.Algorithms.Tokenization.Strategies;

namespace siberianbot.Algorithms.Tokenization
{
    public sealed class Tokenizer
    {
        private readonly ICollection<ITokenizerStrategy> _strategies;

        public Tokenizer(TokenizerOptions options)
        {
            _strategies = options.Strategies;
        }

        public async Task<Token> TokenizeAsync(TextReader reader)
        {
        }

        private class TokenizerContext : ITokenizerContext
        {
            private readonly TextReader _reader;

            public TokenizerContext(TextReader reader)
            {
                _reader = reader;
            }

            public char? Current { get; set; }

            public async Task NextAsync()
            {
                int ch = _reader.Read();

                Current = ch >= 0
                    ? (char) ch
                    : null;
            }

            public char? Peek()
            {
                int ch = _reader.Peek();

                return ch >= 0
                    ? (char) ch
                    : null;
            }

            public void Append(string value)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}