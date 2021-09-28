using System;
using System.Collections;
using System.Collections.Generic;

namespace siberianbot.Tokenization.Tests.Generators
{
    internal sealed class WhitespaceStringGenerator : IEnumerable<object[]>
    {
        private const int Iterations = 5;

        private const int MaxWhitespaces = 20;

        public IEnumerator<object[]> GetEnumerator()
        {
            Random rnd = new();

            for (int i = 0; i < Iterations; i++)
            {
                yield return new object[] {new string(' ', rnd.Next(1, MaxWhitespaces))};
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}