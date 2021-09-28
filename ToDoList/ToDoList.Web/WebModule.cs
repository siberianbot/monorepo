using Autofac;
using ToDoList.DataAccess;
using ToDoList.Services.Command;
using ToDoList.Services.Query;

namespace ToDoList.Web
{
    internal sealed class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterModule<DataAccessModule>()
                .RegisterModule<QueryServicesModule>()
                .RegisterModule<CommandServicesModule>();

            base.Load(builder);
        }
    }
}