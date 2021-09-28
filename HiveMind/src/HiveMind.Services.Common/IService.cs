namespace HiveMind.Services.Common
{
    /// <summary>
    /// Service interface.
    /// Used for marking class/interface for dependency injection, glue generation, etc.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Returns service name.
        /// </summary>
        /// <returns>Service name.</returns>
        string GetServiceName();
    }
}