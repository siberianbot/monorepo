using Autofac;
using ToDoList.Common.DependencyInjection;

namespace ToDoList.DataAccess.Implementation
{
    public sealed class DataAccessModule : DependencyModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGeneric(typeof(ReadRepository<>))
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(WriteRepository<>))
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType(typeof(ContextFactory))
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType(typeof(UnitOfWork))
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}