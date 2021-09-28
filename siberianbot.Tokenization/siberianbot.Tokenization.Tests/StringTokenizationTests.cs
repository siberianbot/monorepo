using System;
using siberianbot.Tokenization.Tests.Generators;
using Xunit;

namespace siberianbot.Tokenization.Tests
{
    /// <summary>
    /// Tests of tokenization using strings (see <see cref="Tokenizer.Parse(string)"/>).
    /// </summary>
    public sealed class StringTokenizationTests
    {
        /// <summary>
        /// Tokenizer throws <see cref="ArgumentNullException"/> if provided string is null.
        /// </summary>
        [Fact]
        public void NullString()
        {
            Assert.Throws<ArgumentNullException>(() => new Tokenizer().Parse((string) null));
        }

        /// <summary>
        /// Tokenizer returns null if string is empty.
        /// </summary>
        [Fact]
        public void EmptyString()
        {
            Assert.Null(new Tokenizer().Parse(string.Empty));
        }

        /// <summary>
        /// Tokenizer returns null if string contains only whitespace characters
        /// and <see cref="TokenizerOptions.IncludeWhitespaces"/> is false. 
        /// </summary>
        [Theory]
        [ClassData(typeof(WhitespaceStringGenerator))]
        public void WhitespaceString(string str)
        {
            TokenizerOptions options = TokenizerOptions.Default;
            options.IncludeWhitespaces = false;

            Tokenizer tokenizer = new(options);

            Assert.Null(tokenizer.Parse(str));
        }
    }
}