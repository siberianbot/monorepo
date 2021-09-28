using Accounting.DataAccess.Implementation.Internal;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Accounting.DataAccess.Implementation
{
    public sealed class DataAccessModule<TDbContext, TDbContextProvider> : Module
        where TDbContext : DbContext 
        where TDbContextProvider : DbContextProvider<TDbContext>
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGeneric(typeof(ReadRepository<,>))
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(WriteRepository<>))
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<TDbContextProvider>()
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}