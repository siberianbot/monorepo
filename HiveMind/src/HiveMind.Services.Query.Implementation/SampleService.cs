using System;
using System.Threading.Tasks;
using HiveMind.Services.Common.Implementation;
using JetBrains.Annotations;

namespace HiveMind.Services.Query.Implementation
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal sealed class SampleService : ServiceBase, ISampleService
    {
        public Task ExecuteAsync()
        {
            Console.WriteLine("SampleService.ExecuteAsync called");

            return Task.CompletedTask;
        }
    }
}