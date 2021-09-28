using Autofac;
using ToDoList.Services.Query.Implementation;

namespace ToDoList.Services.Query
{
    public sealed class QueryServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<WorkItemQueryService>()
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}