using System;

namespace siberianbot.Math.Types
{
    /// <summary>
    ///     Base class for any number.
    /// </summary>
    public abstract class Number : IEquatable<Number>
    {
        public abstract bool Equals(Number number);
        public abstract string ToString(IFormatProvider formatProvider);

        public override bool Equals(object obj)
        {
            return obj != this && obj switch
            {
                Number number => Equals(number),
                _ => false
            };
        }

        public override int GetHashCode()
        {
            return GetHashCodeInternal();
        }

        protected abstract int GetHashCodeInternal();

        #region Operations

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion

        #region Operators

        

        #endregion
    }
}