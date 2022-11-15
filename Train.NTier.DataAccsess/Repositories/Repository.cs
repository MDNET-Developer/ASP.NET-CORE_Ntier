using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Train.NTier.DataAccsess.Context;
using Train.NTier.DataAccsess.Interfaces;

namespace Train.NTier.DataAccsess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ToDoContext _toDoContext;

        public Repository(ToDoContext toDoContext)
        {
            _toDoContext = toDoContext;
        }

        public async Task Create(T entity)
        {
            await _toDoContext.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            //AsNoTracking -ona gore yaziriq ki biz sadece listelemek ucun yaziriq bunu. Goturub elemet uzerinde her hansisa deyisiklik etmeyecekyik ki yeniden savechanges ile bir daha baxaq deyisikliye
            return await _toDoContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetbyFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _toDoContext.Set<T>().SingleOrDefaultAsync(filter):  await _toDoContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetbyId(object id)
        {
            return await _toDoContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQuery()
        {
            return _toDoContext.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _toDoContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _toDoContext.Set<T>().Update(entity);
        }
    }
}
