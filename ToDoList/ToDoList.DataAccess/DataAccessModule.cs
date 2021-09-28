using Autofac;
using ToDoList.DataAccess.Implementation;

namespace ToDoList.DataAccess
{
    public sealed class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ContextProvider>()
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(ReadRepository<>))
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(WriteRepository<>))
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}