using System.Reflection;
using Autofac;
using TeamWorks.DependencyInjection;

namespace TeamWorks.WebApi
{
    internal sealed class WebApiModule : TeamWorksModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            Assembly.Load("TeamWorks.DataAccess.Implementation");
            Assembly.Load("TeamWorks.Services.Query.Implementation");
            
            base.Load(builder);
        }
    }
}