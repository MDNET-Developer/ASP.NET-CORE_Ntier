using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Train.NTier.DataAccsess.Interfaces
{
    public interface IRepository<T> where T : class,new()
    {
        Task<List<T>> GetAll();
        Task<T> GetbyId(object id);
        Task<T> GetbyFilter(Expression<Func<T, bool>> filter,bool asNoTracking=false);
        Task Create(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
