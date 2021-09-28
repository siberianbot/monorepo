using System.Threading.Tasks;
using Accounting.Service.Entries.Models.CreateEntry;
using Accounting.Service.Entries.Models.GetEntries;
using Accounting.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Service.Entries
{
    // TODO: use service methods builder
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly IServiceMethodExecutor _serviceMethodExecutor;

        public EntriesController(IServiceMethodExecutor serviceMethodExecutor)
        {
            _serviceMethodExecutor = serviceMethodExecutor;
        }

        [HttpGet]
        [Route("entries")]
        public async Task<GetEntriesResult> ListEntries([FromQuery] GetEntriesModel model)
        {
            return await _serviceMethodExecutor.ExecuteAsync<GetEntriesModel, GetEntriesResult>(model);
        }

        [HttpPut]
        [Route("entries")]
        public async Task<CreateEntryResult> NewEntry([FromBody] CreateEntryModel model)
        {
            return await _serviceMethodExecutor.ExecuteAsync<CreateEntryModel, CreateEntryResult>(model);
        }
    }
}