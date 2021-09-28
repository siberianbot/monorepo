namespace rengine.API
{
    /// <summary>
    /// Base class for application.
    /// There's allowed only one descendant of <see cref="Application"/>.
    /// </summary>
    public abstract class Application
    {
        #region Static instance and initialization

        /// <summary>
        /// Instance of application.
        /// </summary>
        public static Application Current { get; internal set; }

        #endregion

        /// <summary>
        /// Application initialization handler.
        /// </summary>
        public virtual void Initialization()
        {
            //
        }

        /// <summary>
        /// Application shutdown handler.
        /// </summary>
        public virtual void Shutdown()
        {
            //
        }
    }
}