using System.Collections.Generic;
using Autofac.Core;
using ToDoList.CommandServices.Implementation;
using ToDoList.Common.DependencyInjection;
using ToDoList.DataAccess.Implementation;
using ToDoList.QueryServices.Implementation;

namespace ToDoList.Web
{
    internal sealed class WebModule : DependencyModule
    {
        public override IEnumerable<IModule> Dependencies
        {
            get
            {
                yield return new DataAccessModule();
                yield return new QueryServicesModule();
                yield return new CommandServicesModule();
            }
        }
    }
}