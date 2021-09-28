using System;
using System.Text;
using System.Threading.Tasks;

namespace siberianbot.Algorithms.Tokenization.Strategies
{
    public sealed class LinearStrategy : ITokenizerStrategy
    {
        private readonly Func<char, bool> _matcher;

        public LinearStrategy(Func<char, bool> matcher)
        {
            _matcher = matcher;
        }

        public async Task TokenizeAsync(ITokenizerContext context)
        {
            StringBuilder builder = new StringBuilder();

            char? ch = context.Current;

            while (ch != null && _matcher.Invoke(ch.Value))
            {
                builder.Append(ch);

                ch = context.Peek();

                if (ch != null && _matcher.Invoke(ch.Value))
                {
                    await context.NextAsync();
                }
            }

            if (builder.Length != 0)
            {
                context.Append(builder.ToString());
            }
        }
    }
}