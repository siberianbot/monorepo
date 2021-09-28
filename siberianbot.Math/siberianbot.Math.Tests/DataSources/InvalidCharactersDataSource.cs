using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace siberianbot.Math.Tests.DataSources
{
    internal sealed class InvalidCharactersDataSource : IEnumerable<object[]>
    {
        public const string InvalidCharacters = "@\"'`:;=_[]&%$#<>?\\|{}";

        #region IEnumerable<object[]>

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return InvalidCharacters.Select(ch => new object[] {ch}).GetEnumerator();
        }

        #endregion
    }
}