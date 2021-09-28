namespace siberianbot.Math.Types
{
    public static class NumberOperations
    {
        #region Comparisons

        public static bool Compare(Number left, Number right)
        {
            return left switch
            {
                // Complex == Complex?
                ComplexNumber leftComplex when right is ComplexNumber rightComplex => Compare(leftComplex, rightComplex),
                // Complex == Real?
                ComplexNumber leftComplex when right is RealNumber rightReal && leftComplex.Imaginary == 0 => Compare(leftComplex.Real, rightReal),
                // Real == Complex?
                RealNumber leftReal when right is ComplexNumber rightComplex && rightComplex.Imaginary == 0 => Compare(leftReal, rightComplex.Real),
                // Real == Real?
                RealNumber leftReal when right is RealNumber rightReal => Compare(leftReal, rightReal),
                _ => false
            };
        }

        private static bool Compare(RealNumber left, RealNumber right)
        {
            return left.Value == right.Value;
        }

        private static bool Compare(ComplexNumber left, ComplexNumber right)
        {
            return Compare(left.Real, right.Real) && Compare(left.Imaginary, right.Imaginary);
        }

        #endregion
    }
}