using siberianbot.Math.Types;

namespace siberianbot.Math.Expressions
{
    public static class Expressions
    {
        public static ConstantExpression Constant(RealNumber value)
        {
            return new(value);
        }
    }
}