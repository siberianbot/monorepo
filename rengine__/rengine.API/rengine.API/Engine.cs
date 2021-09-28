using System;
using System.Diagnostics.CodeAnalysis;

namespace rengine.API
{
    /// <summary>
    /// Static class, that contains methods for engine control.
    /// </summary>
    public static class Engine
    {
        #region Shutdown

        /// <summary>
        /// Engine shutdown event arguments.
        /// </summary>
        public sealed class ShutdownEventArgs : EventArgs
        {
            /// <summary>
            /// Engine shutdown caused by some failure.
            /// </summary>
            public bool IsFailure { get; set; }
        }

        /// <summary>
        /// Shutdown event.
        /// This event raised before actual shutdown begins.
        /// </summary>
        public static event EventHandler<ShutdownEventArgs> OnShutdownEvent;

        /// <summary>
        /// Terminate application and shutdown engine.
        /// </summary>
        /// <param name="isFailure">Engine shutdown caused by some failure.</param>
        [DoesNotReturn]
        public static void Shutdown(bool isFailure = false)
        {
            OnShutdownEvent?.Invoke(null, new ShutdownEventArgs
            {
                IsFailure = isFailure
            });

            throw new NotImplementedException();
        }
        
        #endregion
    }
}