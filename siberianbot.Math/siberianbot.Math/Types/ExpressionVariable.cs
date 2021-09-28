using siberianbot.Math.Expressions;

namespace siberianbot.Math.Types
{
    /// <summary>
    ///     Defines a variable with value as expression.
    /// </summary>
    public sealed record ExpressionVariable : Variable
    {
        /// <summary>
        ///     Creates instance of variable.
        /// </summary>
        /// <param name="name">Name of variable.</param>
        /// <param name="expression">Expression for variable.</param>
        public ExpressionVariable(string name, MathExpression expression) : base(name)
        {
            Expression = expression;
        }

        /// <summary>
        ///     Expression for variable.
        /// </summary>
        public MathExpression Expression { get; }

        /// <inheritdoc />
        public override bool HasValue
        {
            get => Expression != null;
        }
    }
}