namespace HiveMind.Services.Common.Implementation
{
    /// <summary>
    /// Base class for any service.
    /// </summary>
    public abstract class ServiceBase : IService
    {
        /// <inheritdoc />
        string IService.GetServiceName()
        {
            return GetType().AssemblyQualifiedName;
        }
    }
}