using System;
using System.IO;

namespace siberianbot.Tokenization.Utils
{
    /// <summary>
    ///     <see cref="TextReader" />, but counts characters.
    /// </summary>
    internal sealed class CountingTextReader : TextReader
    {
        private readonly TextReader _innerReader;
        private int _newLineMatched;

        public CountingTextReader(TextReader innerReader)
        {
            _innerReader = innerReader;

            _newLineMatched = 0;
            CurrentLine = 0;
            CurrentPosition = 0;
        }

        public int CurrentLine { get; private set; }

        public int CurrentPosition { get; private set; }

        public override int Peek()
        {
            return _innerReader.Peek();
        }

        public override void Close()
        {
            _innerReader.Close();
        }

        public override int Read()
        {
            int innerResult = _innerReader.Read();

            if (innerResult != -1)
            {
                char ch = (char) innerResult;

                if (Environment.NewLine[_newLineMatched] == ch)
                {
                    _newLineMatched++;

                    if (_newLineMatched == Environment.NewLine.Length)
                    {
                        CurrentLine++;
                        CurrentPosition = 0;
                        _newLineMatched = 0;
                    }
                }
                else
                {
                    _newLineMatched = 0;
                    CurrentPosition++;
                }
            }

            return innerResult;
        }
    }
}