using Autofac;
using ToDoList.Common.DependencyInjection;

namespace ToDoList.QueryServices.Implementation
{
    public sealed class QueryServicesModule : DependencyModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType(typeof(TaskQueryService))
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}