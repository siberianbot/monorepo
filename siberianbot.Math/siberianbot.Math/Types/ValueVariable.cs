namespace siberianbot.Math.Types
{
    /// <summary>
    ///     Defines a variable with constant value.
    /// </summary>
    public sealed record ValueVariable : Variable
    {
        /// <summary>
        ///     Creates instance of variable.
        /// </summary>
        /// <param name="name">Name of variable.</param>
        /// <param name="value">Value of variable.</param>
        public ValueVariable(string name, RealNumber value) : base(name)
        {
            Value = value;
        }

        /// <summary>
        ///     Numeric value of variable.
        /// </summary>
        public RealNumber Value { get; }

        /// <inheritdoc />
        public override bool HasValue
        {
            get => Value != null;
        }
    }
}