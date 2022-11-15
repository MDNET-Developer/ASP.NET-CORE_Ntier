using System.Threading.Tasks;
using Train.NTier.DataAccsess.Context;
using Train.NTier.DataAccsess.Interfaces;
using Train.NTier.DataAccsess.Repositories;

namespace Train.NTier.DataAccsess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly ToDoContext _context;

        public Uow(ToDoContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
