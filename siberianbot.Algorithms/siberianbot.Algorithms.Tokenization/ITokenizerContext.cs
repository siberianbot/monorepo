using System.Threading.Tasks;

namespace siberianbot.Algorithms.Tokenization
{
    public interface ITokenizerContext
    {
        public char? Current { get; }

        public Task NextAsync();

        public char? Peek();

        public void Append(string value);
    }
}