using System;
using System.Globalization;

namespace siberianbot.Math.Types
{
    /// <summary>
    ///     Represents real number. Based on <see cref="decimal" />.
    /// </summary>
    public sealed class RealNumber : Number
    {
        public RealNumber(decimal value)
        {
            Value = value;
        }

        public decimal Value { get; }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }

        public override string ToString(IFormatProvider formatProvider)
        {
            return Value.ToString(formatProvider);
        }

        public override bool Equals(Number number)
        {
            return number is RealNumber realNumber && realNumber.Value == Value;
        }

        protected override int GetHashCodeInternal()
        {
            return HashCode.Combine(Value);
        }

        public static implicit operator RealNumber(decimal value)
        {
            return new(value);
        }

        public static implicit operator decimal(RealNumber value)
        {
            return value.Value;
        }

        public static readonly RealNumber Zero = new(decimal.Zero);

        public static readonly RealNumber One = new(decimal.One);
    }
}