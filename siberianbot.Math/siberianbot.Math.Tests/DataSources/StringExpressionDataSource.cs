using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using siberianbot.Math.Tests.Models;

namespace siberianbot.Math.Tests.DataSources
{
    internal sealed class StringExpressionDataSource : IEnumerable<object[]>
    {
        public IEnumerable<StringExpression> Expressions
        {
            get
            {
                yield return new StringExpression("2", "+", "2");
                yield return new StringExpression("x", "^", "2", "+", "y", "^", "2");
                yield return new StringExpression("3", "x", "^", "2", "-", "6", "x", "+", "1");
                yield return new StringExpression("2", "+", "2", "*", "2");
                yield return new StringExpression("2", "/", "2", "/", "2");
                yield return new StringExpression("(", "18", "+", "4", "x", ")", "/", "42");
                yield return new StringExpression(Array.Empty<string>());
            }
        }

        #region IEnumerable<object[]>

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return Expressions.Select(expression => new object[] {expression}).GetEnumerator();
        }

        #endregion
    }
}