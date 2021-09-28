namespace siberianbot.Math.Types
{
    /// <summary>
    ///     Defines a variables.
    /// </summary>
    public abstract record Variable
    {
        /// <summary>
        ///     Creates instance of variable.
        /// </summary>
        /// <param name="name">Name of variable.</param>
        protected Variable(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     Name of variable.
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        ///     Variable has value.
        /// </summary>
        public abstract bool HasValue { get; }
    }
}