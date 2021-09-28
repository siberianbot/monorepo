using Autofac;
using ToDoList.Common.DependencyInjection;

namespace ToDoList.CommandServices.Implementation
{
    public sealed class CommandServicesModule : DependencyModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType(typeof(TaskCommandService))
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}