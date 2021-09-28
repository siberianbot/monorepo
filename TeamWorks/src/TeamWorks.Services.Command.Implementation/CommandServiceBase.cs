using System.Threading.Tasks;
using TeamWorks.DataAccess;
using TeamWorks.DomainModel.DataContracts;

namespace TeamWorks.Services.Command.Implementation
{
    internal abstract class CommandServiceBase<TEntity> : ICommandService<TEntity>
        where TEntity : IEntity
    {
        #region Constructor and private fields

        private readonly IWriteRepository<TEntity> _writeRepository;

        protected CommandServiceBase(IWriteRepository<TEntity> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        #endregion

        public TEntity New()
        {
            return _writeRepository.New();
        }

        public Task CreateAsync(TEntity entity)
        {
            return _writeRepository.CreateAsync(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
            return _writeRepository.UpdateAsync(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
            return _writeRepository.DeleteAsync(entity);
        }
    }
}