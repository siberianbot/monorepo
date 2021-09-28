using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;

namespace ToDoList.Common.DependencyInjection
{
    public abstract class DependencyModule : Module
    {
        public virtual IEnumerable<IModule> Dependencies { get; } = Array.Empty<IModule>();

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            foreach (IModule dependency in Dependencies)
            {
                builder.RegisterModule(dependency);
            }
        }
    }
}