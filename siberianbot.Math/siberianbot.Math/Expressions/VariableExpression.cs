using System;
using System.Linq.Expressions;
using siberianbot.Math.Types;

namespace siberianbot.Math.Expressions
{
    public sealed class VariableExpression : MathExpression
    {
        private readonly Variable _variable;

        internal VariableExpression(Variable variable)
        {
            _variable = variable;
        }

        public override ExpressionType NodeType
        {
            get => ExpressionType.Parameter;
        }

        public override MathExpression Derivative(Variable variable)
        {
            if (variable.HasValue)
            {
                throw new ArgumentException($"Variable {variable.Name} has value and can not be used for calculating derivative.");
            }
            
            if (variable == _variable)
            {
                return Expressions.Constant(RealNumber.One);
            }

            if (_variable is ValueVariable {HasValue: true})
            {
                return Expressions.Constant(RealNumber.Zero);
            }

            throw new NotImplementedException("Derivative can not be calculated for unknown variables");
        }
    }
}