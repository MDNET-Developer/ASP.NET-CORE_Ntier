using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.NTier.DataAccsess.Interfaces;

namespace Train.NTier.DataAccsess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T: class,new();
        Task SaveChanges();
    }
}
