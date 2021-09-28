using Microsoft.Extensions.DependencyInjection;

namespace TeamWorks.WebApi
{
    internal sealed partial class Startup
    {
        private void ConfigureControllers(IServiceCollection services) => services.AddControllers();
    }
}