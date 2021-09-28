using System.Threading.Tasks;

namespace siberianbot.Algorithms.Tokenization.Strategies
{
    public interface ITokenizerStrategy
    {
        public Task TokenizeAsync(ITokenizerContext context);
    }
}