using System;

namespace siberianbot.Math.Types
{
    /// <summary>
    /// Represents complex number: a pair of two real numbers R and I, where R is real part of complex number and
    /// I is imaginary part of complex number.
    /// </summary>
    // TODO: doubtful.
    public sealed class ComplexNumber : Number
    {
        public RealNumber Real { get; }
        
        public RealNumber Imaginary { get; }
    
        public ComplexNumber(RealNumber real, RealNumber imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        protected override int GetHashCodeInternal()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(Number number)
        {
            return NumberOperations.Compare(this, number);
        }

        public override string ToString()
        {
            // TODO: exclude imaginary part, put signs when comparison will be done.
            return $"{Real} +/- {Imaginary}i";
        }

        public override string ToString(IFormatProvider formatProvider)
        {
            // TODO: exclude imaginary part, put signs when comparison will be done.
            return $"{Real.ToString(formatProvider)} +/- {Imaginary.ToString(formatProvider)}i";
        }
    }
}