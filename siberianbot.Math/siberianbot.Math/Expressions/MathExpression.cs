using System;
using System.Linq.Expressions;
using siberianbot.Math.Types;

namespace siberianbot.Math.Expressions
{
    public abstract class MathExpression : Expression
    {
        // TODO: add evaluation. 

        protected internal MathExpression()
        {
            //
        }

        /// <inheritdoc />
        public override Type Type
        {
            get => typeof(RealNumber);
        }

        /// <summary>
        /// Calculates derivative.
        /// </summary>
        /// <param name="variable">Name of variable for which we calculate derivative.</param>
        /// <returns>Derivative expression.</returns>
        public abstract MathExpression Derivative(Variable variable);
    }
}