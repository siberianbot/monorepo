using System.Linq.Expressions;
using siberianbot.Math.Types;

namespace siberianbot.Math.Expressions
{
    public sealed class ConstantExpression : MathExpression
    {
        private readonly RealNumber _value;

        internal ConstantExpression(RealNumber value)
        {
            _value = value;
        }

        public override ExpressionType NodeType
        {
            get => ExpressionType.Constant;
        }

        public override MathExpression Derivative(Variable _)
        {
            return new ConstantExpression(RealNumber.Zero);
        }
    }
}