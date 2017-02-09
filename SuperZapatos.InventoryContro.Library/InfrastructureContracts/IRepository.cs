using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.InventoryContro.Library.InfrastructureContracts
{
    public interface IRepository<T> : IDisposable where T : class
    { 
        IQueryable<T> GetAll();
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
        T Find(params object[] keys);
        T Find(Expression<Func<T, bool>> predicate);
        T Create(T t);
        int Delete(T t);    
        int Update(T t);


    }
}
