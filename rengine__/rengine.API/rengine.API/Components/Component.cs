namespace rengine.API.Components
{
    /// <summary>
    /// Component, part of entity.
    /// </summary>
    public abstract class Component
    {
        /// <summary>
        /// Initializes component
        /// </summary>
        public virtual void Init()
        {
            //
        }
        
        /// <summary>
        /// Updates state of component.
        /// </summary>
        /// <param name="passed">Passed time from previous update.</param>
        public virtual void Update(float passed)
        {
            //
        }

        /// <summary>
        /// Destroys instance of component.
        /// </summary>
        public virtual void Destroy()
        {
            //
        }
    }
}