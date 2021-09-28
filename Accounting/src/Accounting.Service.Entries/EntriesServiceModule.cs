using System;
using System.Collections.Generic;
using Accounting.DataAccess.Implementation;
using Accounting.Service.Entries.DataAccess;
using Accounting.Service.Entries.Infrastructure.ServiceMethods;
using Autofac;

namespace Accounting.Service.Entries
{
    internal sealed class EntriesServiceModule : ServiceModule
    {
        protected override IEnumerable<Type> ServiceMethods
        {
            get
            {
                yield return typeof(GetEntriesServiceMethod);
                yield return typeof(CreateEntryServiceMethod);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DataAccessModule<EntriesContext, EntriesContextProvider>>();

            base.Load(builder);
        }
    }
}