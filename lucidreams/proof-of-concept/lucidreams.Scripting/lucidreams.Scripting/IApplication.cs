using System.Threading.Tasks;

namespace lucidreams.Scripting
{
    /// <summary>
    /// Application interface.
    /// There should be only one implementation of <see cref="IApplication"/>.
    /// </summary>
    public interface IApplication : IInjectable
    {
        /// <summary>
        /// TODO
        /// </summary>
        public Task InitializeAsync();

        /// <summary>
        /// TODO
        /// </summary>
        public Task TerminateAsync();
    }
}