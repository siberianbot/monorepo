using Autofac;
using ToDoList.Services.Command.Implementation;

namespace ToDoList.Services.Command
{
    public sealed class CommandServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<WorkItemCommandService>()
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}