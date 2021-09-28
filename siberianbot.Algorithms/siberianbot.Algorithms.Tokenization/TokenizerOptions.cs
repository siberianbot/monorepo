using System.Collections.Generic;
using siberianbot.Algorithms.Tokenization.Strategies;

namespace siberianbot.Algorithms.Tokenization
{
    public sealed class TokenizerOptions
    {
        public ICollection<ITokenizerStrategy> Strategies { get; set; }
    }
}