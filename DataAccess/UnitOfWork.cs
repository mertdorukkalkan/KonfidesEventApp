using System.Threading.Tasks;
using Core.DataAccess;
using Core.Domain;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWorks
    {
        private readonly KonfidesContext _context;

        public UnitOfWork(KonfidesContext context)
        {
            _context = context;
        }

        public IEntityRepository<TEntity> GenerateRepository<TEntity>() where TEntity : BaseEntity, new()
        {
            return new EfEntityRepositoryBase<TEntity, KonfidesContext>(_context);
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }
    }
}